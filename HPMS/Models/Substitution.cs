namespace HPMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Substitution")]
    public partial class Substitution
    {
        [Key]
        [Column("Substution ID")]
        [Display(Name = "Substitution")]
        [StringLength(50)]
        public string Substution_ID { get; set; }

        [Column("Substitution Date", TypeName = "date")]
        [Display(Name = "Substitution Date")]
        [DataType(DataType.Date)]
        public DateTime? Substitution_Date { get; set; }

        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        [Display(Name = "Reason")]
        public string Reason { get; set; }

        [Column("Line ID")]
        [Display(Name = "Line")]
        [StringLength(50)]
        public string Line_ID { get; set; }

        [Display(Name = "Regimen")]
        public string Regimen { get; set; }

        public virtual Patient Patient { get; set; }

        public virtual Substitution_Line Substitution_Line { get; set; }
    }
}
