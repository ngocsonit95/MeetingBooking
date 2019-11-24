using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class LineRoomDetailModel
    {
        public int LineRoomID { get; set; }

        public string LineRoomName { get; set; }

        public string Content { get; set; }

        public int? Status { get; set; }

        public int? NumberPerson { get; set; }

        public DateTime? TimeStart { get; set; }

        public DateTime? TimeEnd { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? Posititon { get; set; }

        public int? RoomID { get; set; }

        public string Description { get; set; }

        public string RoomName { get; set; }

        public int? Seat { get; set; }

        public string FullName { get; set; }

        public string Avatar { get; set; }

        public string FacultyName { get; set; }

        public int? FacultyID { get; set; }
    }
}
