using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YYhUpload.Handle;
using YYhUpload.Model;

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



        public List<TaskRecord> UploadBatchData(string viewName, DateTime begin, DateTime end)
        {
            return viewName switch
            {
                "v_yyh_mjzjybg" => new Mjz_JybgHandle(begin, end).UploadBatch(),
                "v_yyh_mjzjycgbg" => new Mjz_JycgbgHandle(begin, end).UploadBatch(),
                "v_yyh_mjzjysqd" => new Mjz_JysqdHandle(begin, end).UploadBatch(),
                "v_yyh_zyjybg" => new Zy_JybgHandle(begin, end).UploadBatch(),
                "v_yyh_zyjycgbg" => new Zy_JycgbgHandle(begin, end).UploadBatch(),
                "v_yyh_zyjysqd" => new Zy_JysqdHandle(begin, end).UploadBatch(),
                _ => null
            };
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
            cmbView.DataSource = JsonConfig.ViewSets;
            cmbView.ValueMember = "ViewCode";
            cmbView.DisplayMember = "ViewName";
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
            var viewName = this.cmbView.SelectedValue.ToString();
            var viewText = this.cmbView.Text;
            var begin = this.dtpStart.Value;
            var end = this.dtpStop.Value;

            try
            {
                AddRowToTable(DateTime.Now, viewText, $"开始上传，时间范围数据{begin:yyyy年MM月dd日}-{end:yyyy年MM月dd日}");
                var taskList = UploadBatchData(viewName, begin, end);
                if (taskList.Any())
                {
                    foreach (var item in taskList)
                    {
                        AddRowToTable(item.TaskTime,item.TaskName,item.TaskResult);
                    }
                }
               
            }
            catch (Exception ex)
            {
                AddRowToTable(DateTime.Now, viewText, $"数据接收失败,{ex.Message}-{ex.InnerException?.Message}");
            }
            AddRowToTable(DateTime.Now, viewText, $"本次上传任务结束");
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
    }
}
