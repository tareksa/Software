namespace Software.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GradesTb")]
    public partial class GradesTb
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string CourseID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string StudentID { get; set; }

        public int? GradeA { get; set; }

        public int? GradeB { get; set; }
    }
}
