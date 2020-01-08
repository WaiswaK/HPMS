namespace HPMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Demographic")]
    public partial class Demographic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Demographic()
        {
            Patients = new HashSet<Patient>();
            Staffs = new HashSet<Staff>();
        }

        [Key]
        [StringLength(50)]
        public string NIN { get; set; }

        [Column("Given Name")]
        [Display(Name = "Given Name")]
        [Required]
        public string Given_Name { get; set; }

        [Column("Midle Name")]
        [Display(Name = "Midle Name")]
        public string Midle_Name { get; set; }

        [Column("Family Name")]
        [Display(Name = "Family Name")]
        [Required]
        public string Family_Name { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Column("Date of Birth", TypeName = "date")]
        [Display(Name = "Date of Birth")]
        public DateTime? Date_of_Birth { get; set; }

        public string Address { get; set; }

        [Column("Phone Number")]
        [Display(Name = "Phone Number")]
        [StringLength(50)]
        public string Phone_Number { get; set; }

        [StringLength(50)]
        public string District { get; set; }

        [StringLength(50)]
        public string Division { get; set; }

        [StringLength(50)]
        public string Parish { get; set; }

        [StringLength(50)]
        public string Village { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
