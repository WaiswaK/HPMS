namespace HPMS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Health Center")]
    public partial class Health_Center
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Health_Center()
        {
            Patients = new HashSet<Patient>();
        }
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
}
