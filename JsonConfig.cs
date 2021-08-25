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
    }
    public class ViewSet
    {
        public string Index { get; set; }
        public string ViewName { get; set; }
        public string SetCode { get; set; }
        public string Sql { get; set; }
        public string Use { get; set; }
    }


}
