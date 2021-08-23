using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYhUpload.Model
{
    public class YYhResult
    {
        public YYhBaseReturn LastReturn { get; set; }
        private IList<TaskRecord> TasksList { get; set; }
    }

    public class TaskRecord
    {
        public string TaskName { get; set; }
        public DateTime TaskTime { get; set; }
        public string TaskResult { get; set; }
    }
}
