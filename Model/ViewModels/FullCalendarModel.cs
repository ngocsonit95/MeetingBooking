using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class FullCalendarModel
    {
        public int? id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }

    }
}
