namespace HPMS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Demographic")]
    public partial class Demographic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Demographic()
        {
            Exposed_Infant = new HashSet<Exposed_Infant>();
            Family_Member = new HashSet<Family_Member>();
            Forum_Comment = new HashSet<Forum_Comment>();
            Forum_Header = new HashSet<Forum_Header>();
            Patients = new HashSet<Patient>();
            Sexual_Partner = new HashSet<Sexual_Partner>();
            Staffs = new HashSet<Staff>();
        }

        [Key]
        [StringLength(50)]
        public string NIN { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Profile picture")]
        public string ImagePath { get; set; }

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

        [Column("Marital status")]
        [Display(Name = "Marital status")]
        [StringLength(50)]
        public string Marital_status { get; set; }

        [Column("Date of Birth", TypeName = "date")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
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

        [StringLength(128)]
        public string Id { get; set; }

        [Column("Full Name")]
        [Display(Name = "Full Name")]
        public string Full_Name { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exposed_Infant> Exposed_Infant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family_Member> Family_Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Forum_Comment> Forum_Comment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Forum_Header> Forum_Header { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sexual_Partner> Sexual_Partner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
