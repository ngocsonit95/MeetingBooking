using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class ListRoomModel
    {
        public int roomID { get; set; }
        public string roomName { get; set; }
        public string roomAvatar { get; set; }
        public string desc { get; set; }
        public int? seat { get; set; }
        public bool? videoCall { get; set; }
        public bool? phoneCall { get; set; }
        public bool? visible { get; set; }
        public List<LineRoom> listLineRoom { get; set; }
    }

    public class ListTimeLine
    {
        public DateTime? timeEnd { get; set; }
        public DateTime? timeStart { get; set; }

    }
}
