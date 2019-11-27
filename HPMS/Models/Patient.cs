namespace HPMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            COHORTs = new HashSet<COHORT>();
            Visits = new HashSet<Visit>();
        }

        [Key]
        [StringLength(50)]
        public string PID { get; set; }

        [Required]
        [StringLength(50)]
        public string NIN { get; set; }

        [Column("Next of Kin")]
        public string Next_of_Kin { get; set; }

        [Column("Special Category")]
        [StringLength(50)]
        public string Special_Category { get; set; }

        [Column("Care Entry Point")]
        [StringLength(50)]
        public string Care_Entry_Point { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COHORT> COHORTs { get; set; }

        public virtual Demographic Demographic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
