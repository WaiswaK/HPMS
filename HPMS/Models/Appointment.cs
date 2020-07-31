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

        [Column("Appointment Date", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime Appointment_Date { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        [Required]
        [StringLength(50)]
        public string Doctor { get; set; }

        public bool? Accepted { get; set; }

        public bool? Rescheduled { get; set; }

        [Column("Rescheduled Date", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? Rescheduled_Date { get; set; }

        public bool? Completed { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
