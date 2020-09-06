namespace HPMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("COHORT")]
    public partial class COHORT
    {
        [Key]
        [Column("COHORT ID")]
        [Display(Name = "COHORT")]
        [StringLength(50)]
        public string COHORT_ID { get; set; }

        [Column("Date of Start")]
        [Display(Name = "Date of Start")]
        [DataType(DataType.Date)]
        public DateTime? Date_of_Start { get; set; }

        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
