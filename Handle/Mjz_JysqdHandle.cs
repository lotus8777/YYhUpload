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
    public class Mjz_JysqdHandle : BaseHandle<Mjz_Jysqd>
    {
        public Mjz_JysqdHandle(DateTime beginTime, DateTime endTime):base(beginTime,endTime)
        {
            StandardCode = "REQ.C0101.0303.01";
            SetCode = "C0101.0303.01";
            ServiceCode = "XBSJCJCJL:SJSCL";
            DataList = GetDataList();
        }
        public List<Mjz_Jysqd> GetDataList()
        {

            var context = new YYhContext();
            string sql = @$"select * from v_yyh_mjzjysqd 
                            where WS06_00_917_01>='{BeginTime:yyyyMMddhhmmss}' 
                            and WS06_00_917_01<'{EndTime:yyyyMMddhhmmss}' 
                            and WS02_01_030_01 is not null 
                            and WS01_00_010_01 is not null 
                            and WS01_00_008_03 is not null 
                            and WS06_00_901_01 is not null 
                            and WS01_00_907_01 is not null";
           return  context.Database.SqlQuery<Mjz_Jysqd>(sql).ToList();
        }



        public string GetJsonResult()
        {
            var list = GetDataList();
            return list.Any() ? JsonConvert.SerializeObject(list, JsonSettings) : null;
        }
    }
}
