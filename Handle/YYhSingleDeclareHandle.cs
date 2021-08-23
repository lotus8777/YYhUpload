using YYhUpload.Model;

namespace YYhUpload.Handle
{
    public class YYhSingleDeclareHandle
    {

        /// <summary>
        /// 或单次任务号
        /// </summary>
        /// <param name="colrescode"></param>
        /// <param name="setcode"></param>
        /// <param name="taskId"></param>
        /// <param name="taskIndex"></param>
        /// <param name="dataNumber"></param>
        public string GetXmlString(string colrescode, string setcode, string taskId,int taskIndex, int dataNumber)
        {

            var singleDeclare = new YYhSingleDeclare()
            {
                switchset = new SingleDeclareSwitchset()
                {
                    authority = new SingleDeclareSwitchsetAuthority(),
                    provider = new SingleDeclareSwitchsetProvider(),
                    serviceinf = new SingleDeclareSwitchsetServiceinf(),
                    visitor = new SingleDeclareSwitchsetVisitor()
                },
                business = new SingleDeclareBusiness()
                {
                    requestset = new SingleDeclareBusinessRequestset(),
                    businessdata = new SingleDeclareBusinessData()
                    {
                        singledeclare = new SingleDeclare()
                        {
                            totaltaskid = taskId,
                            colrescode = colrescode,
                            sn = taskIndex,
                            declare = new SDeclare()
                            {
                                setcode = setcode,
                                datanum = dataNumber
                            }
                        }
                    }
                },
            };
            return XmlUtils<YYhSingleDeclare>.SerializeToXmlString(singleDeclare);
        }
    }
}
