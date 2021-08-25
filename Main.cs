using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace YYhUpload
{
    public partial class Main : Form
    {
        public JsonConfig JsonConfig;
        private DataTable gridTable;
        public Main()
        {
            InitializeComponent();
            JsonConfig = GetGenericConfig();
            AppInitializer();

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 初始化DataTable
        /// </summary>
        /// <returns></returns>
        private DataTable InitialUploadTable()
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("时间", Type.GetType("System.String"));
            dataTable.Columns.Add("事件", Type.GetType("System.String"));
            dataTable.Columns.Add("操作结果", Type.GetType("System.String"));
            return dataTable;
        }


        /// <summary>
        /// 整个程序的初始化操作
        /// </summary>
        private void AppInitializer()
        {
            InitializeViewCombobox();
            InitializeGridView();


        }
        /// <summary>
        /// 初始化下拉列表
        /// </summary>
        private void InitializeViewCombobox()
        {
            cmbView.DataSource = JsonConfig.ViewSets.Where(p=>p.Use=="1").ToList();
            cmbView.ValueMember = "Index";
            cmbView.DisplayMember = "ViewName";
            this.cmbDbType.SelectedIndex = 0;
        }

        /// <summary>
        /// 初始化结果数据表格
        /// </summary>
        private void InitializeGridView()
        {
            if (gridTable is null)
            {
                gridTable = InitialUploadTable();
            }
            dgvResult.DataSource = gridTable;
        }


        private static JsonConfig GetGenericConfig()
        {
            var path = $@"{AppContext.BaseDirectory}\App.json";
            return JsonConvert.DeserializeObject<JsonConfig>(File.ReadAllText(path), new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            });
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var index = this.cmbView.SelectedValue.ToString();
            var viewName = this.cmbView.Text;
            var begin = this.dtpStart.Value.Date;
            var end = this.dtpStop.Value.Date.AddDays(1).AddMilliseconds(-1);
            var dbType = this.cmbDbType.Text;

            try
            {
                var onceNumber = 10000;
                AddRowToTable(DateTime.Now, viewName, $"开始上传，时间范围{begin:yyyy年MM月dd日}-{end:yyyy年MM月dd日}");
                var viewSet = JsonConfig.ViewSets.FirstOrDefault(p => p.ViewName == viewName);
                if (viewSet?.SetCode is null || viewSet.Sql is null)
                {
                    MessageBox.Show("App.json配置文件中SetCode与Sql语句不能为空");
                    return;
                }
                //拼接视图查询语句
                string querySql = string.Format(viewSet.Sql, $"{begin:yyyyMMddHHmmss}", $"{end:yyyyMMddHHmmss}");
                AddRowToTable(DateTime.Now, viewName, $"sql语句：{querySql}");
                //查询视图数据
                AddRowToTable(DateTime.Now, viewName, $"开始获取视图数据");
                var table = GenericService.GetDataTable(dbType, querySql);
                if (table?.Rows.Count>0)
                {
                   
                    var xElement = GenericService.DataTableToXElement(table);
                    var dataList = GenericService.GetXmlNodeStringList(xElement);
                    var dataNumber = dataList.Count;
                    
                    var taskCount = (int)Math.Ceiling((decimal)dataNumber / onceNumber);
                    AddRowToTable(DateTime.Now, viewName, $"获取到{dataNumber}条数据，分{taskCount}次上传");
                    string batchTaskId =
                        GenericService.GetBatchTaskId(viewSet.SetCode, begin, end, taskCount, dataNumber);
                    AddRowToTable(DateTime.Now, viewName, $"成功获取批量任务号：{batchTaskId}");
                    int remainNumber = dataNumber;
                    for (int i = 1; i <=taskCount; i++)
                    {
                       
                        int useNumber = 0;
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

                        if (useNumber>0)
                        {
                            AddRowToTable(DateTime.Now, viewName, $"第{i}次任务,上传{useNumber}条数据，");
                            string singleTaskId =
                                GenericService.GetSingleTaskId(batchTaskId, viewSet.SetCode, useNumber);
                            AddRowToTable(DateTime.Now, viewName, $"第{i}次任务,单次任务号{singleTaskId}，");
                            var upList= dataList.Skip((i - 1) * onceNumber).Take(useNumber).ToList();
                            var dateset = GenericService.GetUploadDataSets(upList,viewSet.SetCode);
                            var compressDate = GenericService.CompressDataToBase64(dateset);
                            var upTaskId = GenericService.UploadTaskData(singleTaskId, viewSet.SetCode, compressDate);
                            AddRowToTable(DateTime.Now, viewName, $"第{i}次任务上传成功,返回任务号{upTaskId}");
                        }

                    }
                }
                AddRowToTable(DateTime.Now, viewName, $"没有获取到视图数据");
            }
            catch (Exception ex)
            {
                AddRowToTable(DateTime.Now, viewName, $"{ex.Message}");
            }
            AddRowToTable(DateTime.Now, viewName, $"上传任务结束");
        }

        private void AddRowToTable(DateTime? date, string eventName, string eventResult)
        {
            if (gridTable is null)
            {
                gridTable = InitialUploadTable();
            }

            var row = gridTable.NewRow();
            row["时间"] = date?.ToString("yyyy-MM-dd hh:mm:ss");
            row["事件"] = eventName;
            row["操作结果"] = eventResult;

            gridTable.Rows.Add(row);
            dgvResult.DataSource = gridTable;
            dgvResult.Refresh();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
