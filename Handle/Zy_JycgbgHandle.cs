using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Fy3y.Model.YYH;
using Newtonsoft.Json;
using YYhUpload.Model;

namespace YYhUpload.Handle
{
    /// <summary>
    /// 获取门诊急诊常规报告
    /// </summary>
    public class Zy_JycgbgHandle : BaseHandle<Zy_Jycgbg>
    {
        public Zy_JycgbgHandle(DateTime begin,DateTime end):base(begin,end)
        {
            SetCode = "C0102.0303.0201";
            StandardCode = $"REQ.{SetCode}";
            DataList = GetDataList();
        }
        public List<Zy_Jycgbg> GetDataList()
        {
            var context = new YYhContext();
            string sql = @$"select * from v_yyh_zyjycgbg 
                            where WS06_00_926_01>='{BeginTime:yyyyMMddhhmmss}'  
                            and WS06_00_926_01<'{EndTime:yyyyMMddhhmmss}'  
                            and WS02_01_030_01 is not null 
                            and WS01_00_014_01 is not null 
                            and WS01_00_018_01 is not null 
                            and WS01_00_907_01 is not null";
            return context.Database.SqlQuery<Zy_Jycgbg>(sql).ToList();
        }

        public string GetJsonResult()
        {
            var list = GetDataList();
            return list.Any() ? JsonConvert.SerializeObject(list, JsonSettings) : null;
        }
    }
}
