using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using YYhUpload.Model;

namespace YYhUpload.Handle
{
    public abstract class BaseHandle<T>
    {
        public List<T> DataList { get; set; }
        public string StandardCode { get; set; }
        public string SetCode { get; set; }
        public string ServiceCode { get; set; }= "XBSJCJCJL:SJSCL";

        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public YYhBatchReport BaseBatchReport { get; set; }
        protected JsonSerializerSettings JsonSettings { get; set; }

        protected BaseHandle(DateTime begin,DateTime end)
        {
            BeginTime = begin;
            EndTime = end;
            BaseBatchReport = new YYhBatchReport
            {
                switchset = new BatchReportSwitchset()
                {
                    authority = new BatchReportSwitchsetAuthority(),
                    visitor = new BatchReportSwitchsetVisitor(),
                    serviceinf = new BatchReportSwitchsetServiceinf(),
                    provider = new BatchReportSwitchsetProvider()
                },
                business = new BatchReportBusiness()
                {
                    requestset = new BatchReportBusinessRequestset()
                    {
                        reqcondition = new BatchReportReqcondition()
                        {
                            condition = new BatchReportReqconditionCondition()
                        }
                    }
                }
            };
            JsonSettings = new JsonSerializerSettings
            {
                ContractResolver = new NullToEmptyStringResolver()
            };
        }
        /// <summary>
        /// 获取传入的数据列表获取businessData的Xml字符串
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <returns></returns>
        public string GetBusinessData(List<T> list)
        {
            var batchReport = new BusinessData<T>()
            {
                datasets = new BusinessDateSets<T>()
                {
                    setdetails = list,
                    setcode = SetCode
                }
            };
            return XmlUtils<BusinessData<T>>.SerializeToXmlString(batchReport);
        }
        /// <summary>
        /// 获取完成的上传字符串
        /// </summary>
        /// <param name="subList">本次上传的数据子列表</param>
        /// <param name="taskId">此次批量上传的单次ID</param>
        /// <returns></returns>
        public string GetBatchReportXml(List<T> subList, string taskId)
        {
            BaseBatchReport.switchset.serviceinf.servicecode = ServiceCode;
            BaseBatchReport.business.standardcode = StandardCode;
            BaseBatchReport.business.daqtaskid = taskId;
            BaseBatchReport.business.datacompress = 1;
            var businessData = GetBusinessData(subList);
            BaseBatchReport.business.businessdata = DataCompress.CompressDataToBase64(businessData);
            return XmlUtils<YYhBatchReport>.SerializeToXmlString(BaseBatchReport);

        }
        public List<TaskRecord> UploadBatch()
        {
            var taskList = new List<TaskRecord>();
            var totalCount = DataList.Count;
            if (totalCount > 0)
            {
                var dataList = GetNoNulList(DataList);
                taskList.Add(new TaskRecord()
                {
                    TaskName = "获取数据成功",
                    TaskTime = DateTime.Now,
                    TaskResult = $"共有{totalCount}条记录待上传"
                });
                var batchHandle = new YYhBatchNumberHandle();
                var onceNumber = 10000;
                var taskNumber = (int)Math.Ceiling((decimal)totalCount / onceNumber);
                var batchPara = batchHandle.GetXmlString(StandardCode, SetCode, BeginTime, EndTime, totalCount, taskNumber);
                var batchNumberClient = new YYhBatchService.CollectDeclareServiceClient();
                var batchReturnPara = batchNumberClient.totalDeclare(batchPara);
                var batchReturn = XmlUtils<YYhBaseReturn>.XmlDeserialize(batchReturnPara);
                if (!string.IsNullOrEmpty(batchReturn.switchset.switchmessage.messagecode))
                {
                    throw new Exception("获取批次号失败");
                }

                if (batchReturn.business.returnmessage.retcode == 1)
                {
                   
                    var taskId = batchReturn.business.businessdata.taskid;
                    taskList.Add(new TaskRecord()
                    {
                        TaskName = "获取任务批次号成功",
                        TaskTime = DateTime.Now,
                        TaskResult = $"任务批次号{taskId},需分{taskNumber}次上传"
                    });
                    var remainNumber = totalCount;
                    var singleHandle = new YYhSingleDeclareHandle();
                    var singleClient = new YYhSingleService.CollectDeclareServiceClient();
                    for (var i = 1; i <= taskNumber; i++)
                    {
                        int useNumber;
                        if (remainNumber > onceNumber)
                        {
                            useNumber = onceNumber;
                            remainNumber -= onceNumber;
                        }
                        else
                        {
                            useNumber = remainNumber;
                            remainNumber = 0;
                        }

                        var singleDeclareIn = singleHandle.GetXmlString(StandardCode, SetCode, taskId, i, useNumber);
                        var singleReturnPara = singleClient.singleDeclare(singleDeclareIn);
                        var singleReturn = XmlUtils<YYhBaseReturn>.XmlDeserialize(singleReturnPara);
                        if (!string.IsNullOrEmpty(singleReturn.switchset.switchmessage.messagecode))
                        {
                            taskList.Add(new TaskRecord()
                            {
                                TaskName = "获取任务单次号失败",
                                TaskTime = DateTime.Now,
                                TaskResult = $"第{i}次获取单次号"
                            });
                            continue;
                        }

                        if (singleReturn.business.returnmessage.retcode == 1)
                        {
                            var singleTaskId = singleReturn.business.businessdata.taskid;
                            var data = dataList.Skip((i - 1) * onceNumber).Take(useNumber).ToList();
                            taskList.Add(new TaskRecord()
                            {
                                TaskName = "获取任务单次次号成功",
                                TaskTime = DateTime.Now,
                                TaskResult = $"任务编号{singleTaskId},本次上传{useNumber}条记录"
                            });
                            var reportXml = GetBatchReportXml(data, singleTaskId);
                            var client = new YYhUploadService.CarryXmlToDbServiceClient();
                            var rtn = client.handle(reportXml);
                            var subReturn= XmlUtils<YYhBaseReturn>.XmlDeserialize(rtn);
                            if (subReturn.business.returnmessage.retcode==1)
                            {
                                taskList.Add(new TaskRecord()
                                {
                                    TaskName = "上传成功",
                                    TaskTime = DateTime.Now,
                                    TaskResult = $"第{i}次上传成功，本次任务号{subReturn.business.businessdata.taskid}"
                                });
                            }
                            else
                            {
                                taskList.Add(new TaskRecord()
                                {
                                    TaskName = "上传失败",
                                    TaskTime = DateTime.Now,
                                    TaskResult = $"第{i}次上传失败"
                                });
                            }
                        }
                        else
                        {
                            taskList.Add(new TaskRecord()
                            {
                                TaskName = "获取任务单次号失败",
                                TaskTime = DateTime.Now,
                                TaskResult = $"第{i}次获取单次号"
                            });
                        }
                    }
                }
            }
            else
            {
                taskList.Add(new TaskRecord()
                {
                    TaskName = "上传数据为空",
                    TaskTime = DateTime.Now,
                    TaskResult = $"没有需要上传的数据"
                });
            }

           

            return taskList;
        }

        /// <summary>
        /// 将空值转为empty
        /// </summary>
        /// <returns></returns>
        public List<T> GetNoNulList(List<T> list)
        {
            var newList = new List<T>();
            if (list.Any())
            {
                foreach (var item in list)
                {
                    var json = JsonConvert.SerializeObject(item,
                        new JsonSerializerSettings() { ContractResolver = new NullToEmptyStringResolver() });
                    newList.Add(JsonConvert.DeserializeObject<T>(json));
                }
            }
            return newList;
        }
    }
}
