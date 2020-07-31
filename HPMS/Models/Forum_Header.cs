namespace HPMS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Forum Header")]
    public partial class Forum_Header
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Forum_Header()
        {
            Forum_Comment = new HashSet<Forum_Comment>();
        }

        [StringLength(50)]
        public string ID { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Forum")]
        public string Topic { get; set; }

        [StringLength(50)]
        public string NIN { get; set; }

        public virtual Demographic Demographic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Forum_Comment> Forum_Comment { get; set; }
    }
}
