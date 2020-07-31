namespace HPMS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Patient Diet Chart")]
    public partial class Patient_Diet_Chart
    {
        [Key]
        [StringLength(50)]
        public string PDC { get; set; }

        [StringLength(50)]
        [Display(Name = "Diet Chart")]
        public string DC { get; set; }

        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        public virtual Diet_Chart Diet_Chart { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
