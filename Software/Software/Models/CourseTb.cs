namespace Software.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CourseTb")]
    public partial class CourseTb
    {
        [StringLength(50)]
        public string ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Points { get; set; }

        [StringLength(50)]
        public string ExamA { get; set; }

        [StringLength(50)]
        public string ExamB { get; set; }

        [StringLength(50)]
        public string Lecturer { get; set; }

        [StringLength(50)]
        public string Time { get; set; }

        [StringLength(50)]
        public string Day { get; set; }

        [StringLength(50)]
        public string Class { get; set; }
    }
}
