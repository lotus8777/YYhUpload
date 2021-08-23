using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YYhUpload
{

    public class JsonConfig
    {
        public List<ViewSet> ViewSets { get; set; }
        public HospitalSetting HospitalSetting { get; set; }
    }


    public class HospitalSetting
    {
        public string HospitalName { get; set; }
        public string HospitalCode { get; set; }
    }

    public class ViewSet
    {
        public string ViewName { get; set; }
        public string ViewCode { get; set; }
        public string SetCode { get; set; }
        public string Sql { get; set; }
    }


}
