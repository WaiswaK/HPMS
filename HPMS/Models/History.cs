namespace HPMS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("History")]
    public partial class History
    {
        [Required]
        [StringLength(50)]
        public string SID { get; set; }

        [Key]
        [StringLength(50)]
        public string HID { get; set; }

        [Required]
        public string Workpace { get; set; }

        public int Duration { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
