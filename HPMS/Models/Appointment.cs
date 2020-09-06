namespace HPMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Appointment")]
    public partial class Appointment
    {
        [Key]
        [Column("Appointment ID")]
        [StringLength(50)]
        public string Appointment_ID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        [Required]
        [StringLength(50)]
        public string Doctor { get; set; }

        [Column("Appointment Date", TypeName = "date")]
        [Display(Name = "Appointment Date")]
        [DataType(DataType.Date)]
        public DateTime Appointment_Date { get; set; }

        [Column("Appointment Time")]
        [Display(Name = "Appointment Time")]
        [DataType(DataType.Time)]
        public TimeSpan Appointment_Time { get; set; }

        public bool Accepted { get; set; }

        public bool? Rescheduled { get; set; }

        [Column("Rescheduled Date", TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Rescheduled Date")]
        public DateTime? Rescheduled_Date { get; set; }

        [Column("Rescheduled Time")]
        [Display(Name = "Rescheduled Time")]
        [DataType(DataType.Time)]
        public TimeSpan? Rescheduled_Time { get; set; }

        public bool Completed { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
