using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class DataWeekModel
    {
        public string name { get; set; }
        public double y { get; set; }
        public string drilldown { get; set; }
    }

    public class DataLineRoomlModel
    {
        public string name { get; set; }
        public string data { get; set; }
        //public List<object[]> data { get; set; }
    }
}
