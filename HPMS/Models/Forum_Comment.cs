namespace HPMS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Forum Comment")]
    public partial class Forum_Comment
    {
        [StringLength(50)]
        public string ID { get; set; }

        [Column("Forum ID")]
        [StringLength(50)]
        public string Forum_ID { get; set; }

        [StringLength(50)]
        [Display(Name = "User")]
        public string NIN { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        public virtual Demographic Demographic { get; set; }

        public virtual Forum_Header Forum_Header { get; set; }
    }
}
