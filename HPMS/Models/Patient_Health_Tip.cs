namespace HPMS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Patient Health Tip")]
    public partial class Patient_Health_Tip
    {
        [Key]
        [StringLength(50)]
        public string PHT { get; set; }

        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        [StringLength(50)]
        [Display(Name = "Health Tip")]
        public string HT { get; set; }

        public virtual Health_Tip Health_Tip { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
