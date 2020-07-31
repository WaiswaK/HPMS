namespace HPMS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Health Tip")]
    public partial class Health_Tip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Health_Tip()
        {
            Patient_Health_Tip = new HashSet<Patient_Health_Tip>();
        }

        [Key]
        [StringLength(50)]
        public string HT { get; set; }

        [Column(TypeName = "text")]
        public string Tip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient_Health_Tip> Patient_Health_Tip { get; set; }
    }
}
