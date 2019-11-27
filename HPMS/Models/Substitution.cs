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
        [StringLength(50)]
        public string Substution_ID { get; set; }

        [Column("Substitution Date", TypeName = "date")]
        public DateTime? Substitution_Date { get; set; }

        [StringLength(50)]
        public string PID { get; set; }

        [Column("Reason ID")]
        public int? Reason_ID { get; set; }

        [Column("Line ID")]
        [StringLength(50)]
        public string Line_ID { get; set; }

        public string Regimen { get; set; }

        public virtual Reason Reason { get; set; }

        public virtual Reason Reason1 { get; set; }

        public virtual Substitution_Line Substitution_Line { get; set; }
    }
}
