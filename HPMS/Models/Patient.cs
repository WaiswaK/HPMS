namespace HPMS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Patient")]
    public partial class Patient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
            COHORTs = new HashSet<COHORT>();
            Patient_Diet_Chart = new HashSet<Patient_Diet_Chart>();
            Patient_Health_Tip = new HashSet<Patient_Health_Tip>();
            Patient_Medication = new HashSet<Patient_Medication>();
            Substitutions = new HashSet<Substitution>();
            Visits = new HashSet<Visit>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        [Required]
        [StringLength(50)]
        public string NIN { get; set; }

        [Column("Next of Kin")]
        [Display(Name = "Next of Kin")]
        public string Next_of_Kin { get; set; }

        [Column("Special Category")]
        [Display(Name = "Special Category")]
        [StringLength(50)]
        public string Special_Category { get; set; }

        [Column("Care Entry Point")]
        [Display(Name = "Care Entry Point")]
        [StringLength(50)]
        public string Care_Entry_Point { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COHORT> COHORTs { get; set; }

        public virtual Demographic Demographic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient_Diet_Chart> Patient_Diet_Chart { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient_Health_Tip> Patient_Health_Tip { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient_Medication> Patient_Medication { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Substitution> Substitutions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
