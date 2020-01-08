namespace HPMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        public DateTime? Substitution_Date { get; set; }

        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        [Column("Reason ID")]
        [Display(Name = "Reason")]
        public int? Reason_ID { get; set; }

        [Column("Line ID")]
        [Display(Name = "Line")]
        [StringLength(50)]
        public string Line_ID { get; set; }

        public string Regimen { get; set; }

        public virtual Reason Reason { get; set; }

        public virtual Reason Reason1 { get; set; }

        public virtual Substitution_Line Substitution_Line { get; set; }
    }
}
