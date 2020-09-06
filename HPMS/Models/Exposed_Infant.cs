namespace HPMS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Exposed Infant")]
    public partial class Exposed_Infant
    {
        [Key]
        [StringLength(50)]
        public string EEID { get; set; }

        [Required]
        [StringLength(50)]
        public string NIN { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        [Column("Infant Feeding Practices")]
        [Display(Name = "Infant Feeding Practices")]
        public string Infant_Feeding_Practices { get; set; }

        [Column("HIV Test")]
        [Required]
        [StringLength(50)]
        [Display(Name = "HIV Test")]
        public string HIV_Test { get; set; }

        [Column("Results Attempts")]
        [Display(Name = "Results Attempts")]
        public int Results_Attempts { get; set; }

        public virtual Demographic Demographic { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
