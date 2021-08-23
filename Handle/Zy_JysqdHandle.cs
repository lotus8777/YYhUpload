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
    /// 获取住院检验申请单
    /// </summary>
    public class Zy_JysqdHandle : BaseHandle<Zy_Jysqd>
    {
        public Zy_JysqdHandle(DateTime begin, DateTime end) : base(begin, end)
        {
            SetCode = "C0102.0303.01";
            StandardCode = $"REQ.{SetCode}";
            DataList = GetDataList();
        }
        public List<Zy_Jysqd> GetDataList()
        {
            var context = new YYhContext();
            string sql = @$"select * from v_yyh_zyjysqd where WS06_00_917_01>='{BeginTime:yyyyMMddhhmmss}'  and WS06_00_917_01<'{EndTime:yyyyMMddhhmmss}' and WS02_01_030_01 is not null and WS01_00_014_01 is not null";
            return context.Database.SqlQuery<Zy_Jysqd>(sql).ToList();
        }
        public string GetJsonResult()
        {
            var list = GetDataList();
            return list.Any() ? JsonConvert.SerializeObject(list, JsonSettings) : null;
        }


    }
}
