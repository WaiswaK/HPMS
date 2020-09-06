namespace HPMS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Family Member")]
    public partial class Family_Member
    {
        [Key]
        [StringLength(50)]
        public string FMID { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        [Required]
        [StringLength(50)]
        public string Relationship { get; set; }

        [Column("HIV Care")]
        [Required]
        [StringLength(50)]
        [Display(Name = "HIV Care")]
        public string HIV_Care { get; set; }

        [Required]
        [StringLength(50)]
        public string NIN { get; set; }

        public virtual Demographic Demographic { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
