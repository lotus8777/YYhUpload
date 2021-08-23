using System;
using YYhUpload.Model;

namespace YYhUpload.Handle
{
    public class YYhBatchNumberHandle
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="colrescode">交换标准编码</param>
        /// <param name="setcode">数据集编码</param>
        /// <param name="beginTime">数据开始时间</param>
        /// <param name="endTime">数据结束时间</param>
        /// <param name="taskNumber">上传次数</param>
        /// <param name="totalNumber">总数量</param>
        public string GetXmlString(string colrescode, string setcode, DateTime beginTime, DateTime endTime, int totalNumber, int taskNumber )
        {
            var batchNumber = new YyhBatchNumber()
            {
                switchset = new BatchNumberSwitchset()
                {
                    authority = new BatchNumberSwitchsetAuthority(),
                    visitor = new BatchNumberSwitchsetVisitor(),
                    serviceinf = new BatchNumberSwitchsetServiceinf(),
                    provider = new BatchNumberSwitchsetProvider()
                },
                business = new BatchNumberBusiness()
                {
                    requestset =new BatchNumberRequestSet(),
                    businessdata = new BatchNumberBusinessData()
                    {
                        totaldeclare = new TotalDeclare()
                        {
                            colrescode = colrescode,
                            tasknum = taskNumber,
                            begindatetime =$"{beginTime:yyyyMMddHHmmss}",
                            enddatetime = $"{endTime:yyyyMMddHHmmss}",
                            tdeclare = new Tdeclare()
                            {
                                setcode = setcode,
                                datanum = totalNumber
                            }
                        }
                    }
                },
            };
            return XmlUtils<YyhBatchNumber>.SerializeToXmlString(batchNumber);
        }
    }
}
