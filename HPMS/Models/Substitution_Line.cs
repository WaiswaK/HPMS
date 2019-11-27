namespace HPMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Substitution Line")]
    public partial class Substitution_Line
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Substitution_Line()
        {
            Substitutions = new HashSet<Substitution>();
        }

        [Key]
        [Column("Line ID")]
        [StringLength(50)]
        public string Line_ID { get; set; }

        [Column("Line Number")]
        public int? Line_Number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Substitution> Substitutions { get; set; }
    }
}
