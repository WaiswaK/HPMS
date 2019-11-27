namespace HPMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reason")]
    public partial class Reason
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reason()
        {
            Substitutions = new HashSet<Substitution>();
            Substitutions1 = new HashSet<Substitution>();
        }

        [Key]
        [Column("Reson ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Reson_ID { get; set; }

        [Column("Reason")]
        [StringLength(50)]
        public string Reason1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Substitution> Substitutions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Substitution> Substitutions1 { get; set; }
    }
}
