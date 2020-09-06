namespace HPMS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Sexual Partner")]
    public partial class Sexual_Partner
    {
        [Key]
        [StringLength(50)]
        public string SPID { get; set; }

        [Required]
        [StringLength(50)]
        public string NIN { get; set; }

        [Required]
        [StringLength(50)]
        public string PID { get; set; }

        [Required]
        [StringLength(50)]
        public string Relationship { get; set; }

        [Column("HIV Care")]
        [Required]
        [StringLength(50)]
        [Display(Name = "HIV Care")]
        public string HIV_Care { get; set; }

        [Column("Contraceptives Used")]
        [Required]
        [StringLength(50)]
        [Display(Name = "Contraceptives Used")]
        public string Contraceptives_Used { get; set; }

        public virtual Demographic Demographic { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
