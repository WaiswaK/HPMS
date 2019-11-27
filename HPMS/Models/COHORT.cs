namespace HPMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("COHORT")]
    public partial class COHORT
    {
        [Key]
        [Column("COHORT ID")]
        [StringLength(50)]
        public string COHORT_ID { get; set; }

        [Column("Date of Start")]
        [StringLength(50)]
        public string Date_of_Start { get; set; }

        [StringLength(50)]
        public string PID { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
