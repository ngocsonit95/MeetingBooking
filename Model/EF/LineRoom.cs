namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LineRoom")]
    public partial class LineRoom
    {
        public int LineRoomID { get; set; }

        [StringLength(255)]
        public string LineRoomName { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int? Status { get; set; }

        public DateTime? TimeStart { get; set; }

        public DateTime? TimeEnd { get; set; }

        [StringLength(50)]
        public string CreateBy { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string UpdateBy { get; set; }

        public DateTime? UpdateTime { get; set; }

        public int? NumberPerson { get; set; }

        public int? Posititon { get; set; }

        public int? RoomID { get; set; }
    }
}
