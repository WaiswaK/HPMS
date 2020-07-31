namespace HPMS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Heath Center")]
    public partial class Heath_Center
    {
        [Key]
        [StringLength(50)]
        public string HCID { get; set; }

        [StringLength(10)]
        [Display(Name = "Health Center")]
        public string Center { get; set; }

        [StringLength(50)]
        public string Latitude { get; set; }

        [StringLength(50)]
        public string Longtitude { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [StringLength(50)]
        public string Parish { get; set; }
    }
}
