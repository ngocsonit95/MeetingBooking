using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingBooking.Models
{
    public class UserSession
    {

        public string UserID { get; set; }

        public string Password { get; set; }

        public bool? Visible { get; set; }

        public bool? Roles { get; set; }

        public int? Permission { get; set; }

        public int? Position { get; set; }

        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public string FullName { get; set; }

        public string Mobi { get; set; }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public int? FacutlyID { get; set; }

        public string FacutlyName { get; set; }
    }
}
