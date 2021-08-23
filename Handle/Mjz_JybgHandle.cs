using System;
using System.Collections.Generic;
using System.Linq;
using Fy3y.Model.YYH;
using Newtonsoft.Json;

namespace YYhUpload.Handle
{
    /// <summary>
    /// 获取门诊急诊检验报告
    /// </summary>
    public class Mjz_JybgHandle : BaseHandle<Mjz_Jybg>
    {
        public Mjz_JybgHandle(DateTime begin, DateTime end) : base(begin, end)
        {
            SetCode = "C0101.0303.02";
            StandardCode = $"REQ.{SetCode}";
            DataList = GetDataList();
        }
        public List<Mjz_Jybg> GetDataList()
        {
            var context = new YYhContext();
            string sql = @$"select * from v_yyh_mjzjybg 
                            where WS06_00_927_01>='{BeginTime:yyyyMMddhhmmss}' 
                            and WS06_00_927_01<'{EndTime:yyyyMMddhhmmss}' 
                            and WS06_00_925_01 is not null 
                            and WS02_01_030_01 is not null 
                            and WS01_00_010_01 is not null 
                            and WS01_00_008_03 is not null 
                            and WS01_00_018_01 is not null";
           return context.Database.SqlQuery<Mjz_Jybg>(sql).ToList();

        }
        public string GetJsonResult()
        {
            var list = GetDataList();
            return list.Any() ? JsonConvert.SerializeObject(list) : null;
        }
    }
}

