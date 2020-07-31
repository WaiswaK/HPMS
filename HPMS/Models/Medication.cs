namespace HPMS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Medication")]
    public partial class Medication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Medication()
        {
            Patient_Medication = new HashSet<Patient_Medication>();
        }

        [Key]
        [Column("Medical ID")]
        [StringLength(50)]
        public string Medical_ID { get; set; }

        [Column(TypeName = "text")]
        public string Medicine { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient_Medication> Patient_Medication { get; set; }
    }
}
