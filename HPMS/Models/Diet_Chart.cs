namespace HPMS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Diet Chart")]
    public partial class Diet_Chart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Diet_Chart()
        {
            Patient_Diet_Chart = new HashSet<Patient_Diet_Chart>();
        }

        [Key]
        [StringLength(50)]
        public string DC { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient_Diet_Chart> Patient_Diet_Chart { get; set; }
    }
}
