namespace HPMS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Education")]
    public partial class Education
    {
        [Required]
        [StringLength(50)]
        public string SID { get; set; }

        [Key]
        [StringLength(50)]
        public string EID { get; set; }

        [Required]
        public string School { get; set; }

        [Required]
        public string Award { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
