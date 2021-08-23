using System;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Fy3y.Model.YYH;
using Oracle.ManagedDataAccess.Client;

namespace Fy3y.Business.YYH
{
    /// <summary>
    /// 通用视图访问处理类
    /// </summary>
    public class GenericService:IHandle
    {

        private YyhParaIn InPara;
        public GenericService(YyhParaIn inPara)
        {
            InPara = inPara;
        }
        public string GetJsonResult()
        {
            string appKey;
            DbConnection connection;
            DbCommand command;
            DbDataAdapter dataAdapter;
            if (InPara.DatabaseType is "oracle")
            {
                appKey = $"conn_ora_{ InPara.SearchType}";
                connection = new OracleConnection();
                command = new OracleCommand();
                dataAdapter = new OracleDataAdapter();
            }
            else
            {
                appKey = $"conn_sql_{ InPara.SearchType}";
                connection = new SqlConnection();
                command = new SqlCommand();
                dataAdapter = new SqlDataAdapter();
            }

            connection.ConnectionString = ConfigurationManager.AppSettings[appKey];
            connection.Open();
            command.CommandType = CommandType.Text;
            command.Connection = connection;
            command.CommandText = InPara.ViewPara;
            command.CommandTimeout = 120;
            var dataTemp = new DataSet();
            dataAdapter.SelectCommand = command;//检索command设置
            dataAdapter.Fill(dataTemp);//将检索结果保存到data_temp数据集
            if (dataTemp.Tables.Count > 0 && dataTemp.Tables[0].Rows?.Count > 0)
            {
                return ToJson(dataTemp.Tables[0]);
            }
            return null;
        }

        /// <summary>
        /// DataTable转换为Json
        /// </summary>
        /// <param name="dt">DataTable对象</param>
        /// <returns>Json字符串</returns>
        private static string ToJson(DataTable dt)
        {
            var jsonString = new StringBuilder();
            jsonString.Append("[");
            var drc = dt.Rows;
            for (var i = 0; i < drc.Count; i++)
            {
                jsonString.Append("{");
                for (var j = 0; j < dt.Columns.Count; j++)
                {
                    var strKey = dt.Columns[j].ColumnName;
                    var strValue = drc[i][j].ToString();
                    var type = dt.Columns[j].DataType;
                    jsonString.Append("\"" + strKey + "\":");
                    if (j < dt.Columns.Count - 1)
                    {
                        jsonString.Append("\"" + StringFormat(strValue, type) + "\",");
                    }
                    else
                    {
                        jsonString.Append("\"" + StringFormat(strValue, type) + "\"");
                    }
                }
                jsonString.Append("},");
            }
            jsonString.Remove(jsonString.Length - 1, 1);
            jsonString.Append("]");
            return jsonString.ToString();
        }
        /// <summary>
        /// 格式化字符型、日期型、布尔型
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string StringFormat(string strValue, Type type)
        {
            if (type == typeof(string))
            {
                strValue = String2Json(strValue);
            }
            else
            {
                strValue = type == typeof(bool) ? strValue.ToLower() : string.Format(strValue, type);
            }
            return strValue;
        }

        /// <summary>
        /// 过滤特殊字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string String2Json(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            var sb = new StringBuilder();
            var charArray = s.ToCharArray();
            if (charArray.Length > 0)
            {
                foreach (var charItem in charArray)
                {
                    switch (charItem)
                    {
                        case '\"':
                            sb.Append("\\\""); break;
                        case '\\':
                            sb.Append("\\\\"); break;
                        case '/':
                            sb.Append("\\/"); break;
                        case '\b':
                            sb.Append("\\b"); break;
                        case '\f':
                            sb.Append("\\f"); break;
                        case '\n':
                            sb.Append("\\n"); break;
                        case '\r':
                            sb.Append("\\r"); break;
                        case '\t':
                            sb.Append("\\t"); break;
                        default:
                            sb.Append(charItem); break;
                    }
                }
            }
            return sb.ToString();
        }

        public string GetXmlResult()
        {
            throw new NotImplementedException();
        }
    }
}
