namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class Room
    {
        public int RoomID { get; set; }

        [StringLength(50)]
        public string RoomName { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? Seat { get; set; }

        public bool? PhoneCall { get; set; }

        public bool? VideoCall { get; set; }

        public int? Position { get; set; }

        public int? AreaID { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? NumberPeople { get; set; }

        public bool? Visible { get; set; }
    }
}
