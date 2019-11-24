using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
   public class ListUserModel
    {
        public string userID { get; set; }
        public string fullName { get; set; }
        public string userAvatar { get; set; }
        public string password { get; set; }
        public string mobi { get; set; }
        public string email { get; set; }
        public string createBy { get; set; }
        public bool? visible { get; set; }
        public bool? roles { get; set; }
        public DateTime? createTime { get; set; }
    }
}
