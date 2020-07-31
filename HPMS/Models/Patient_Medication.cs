namespace HPMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Patient Medication")]
    public partial class Patient_Medication
    {
        [Key]
        [StringLength(50)]
        public string PMedID { get; set; }

        [Column("Medication ID")]
        [Required]
        [StringLength(50)]
        public string Medication_ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        [Column("Time for  Medication")]
        [Display(Name = "Time for Medication")]
        public TimeSpan? Time_for__Medication { get; set; }

        public virtual Medication Medication { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
