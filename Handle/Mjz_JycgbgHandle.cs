using System;
using System.Collections.Generic;
using System.Linq;
using Fy3y.Model.YYH;
using Newtonsoft.Json;

namespace YYhUpload.Handle
{
    /// <summary>
    /// 获取门诊急诊常规报告
    /// </summary>
    public class Mjz_JycgbgHandle : BaseHandle<Mjz_Jycgbg>
    {
        public Mjz_JycgbgHandle(DateTime begin,DateTime end):base(begin,end)
        {
           
            SetCode = "C0101.0303.0201";
            StandardCode = $"REQ.{SetCode}";
            DataList = GetDataList();
        }
        public List<Mjz_Jycgbg> GetDataList()
        {

            var context = new YYhContext();
            string sql = @$"select * from v_yyh_mjzjycgbg 
                            where WS06_00_926_01>='{BeginTime:yyyyMMddhhmmss}' 
                            and WS06_00_926_01<'{EndTime:yyyyMMddhhmmss}' 
                            and WS01_00_010_01 is not null 
                            and WS02_01_906_01 is not null 
                            and WS01_00_008_03 is not null 
                            and WS01_00_018_01 is not null 
                            and WS01_00_907_01 is not null
";
            return context.Database.SqlQuery<Mjz_Jycgbg>(sql).ToList();

        }


        public string GetJsonResult()
        {
            var list = GetDataList();
            return list.Any() ? JsonConvert.SerializeObject(list, JsonSettings) : null;
        }
    }
}
