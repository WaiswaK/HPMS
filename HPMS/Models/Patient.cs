namespace HPMS.Models
{
    using System;
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
            Exposed_Infant = new HashSet<Exposed_Infant>();
            Family_Member = new HashSet<Family_Member>();
            Sexual_Partner = new HashSet<Sexual_Partner>();
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

        [Column("Mode of Transmission")]
        [StringLength(50)]
        [Display(Name = "Mode of Transmission")]
        public string Mode_of_Transmission { get; set; }

        [Column("Average Monthly Income")]
        [Display(Name = "Average Monthly Income")]
        public decimal? Average_Monthly_Income { get; set; }

        [StringLength(50)]
        public string Occupation { get; set; }

        public int? Dependents { get; set; }

        [Column("Drug Allergies")]
        [Display(Name = "Drug Allergies")]
        public string Drug_Allergies { get; set; }

        [Column("Relevant Medical Conditions")]
        [Display(Name = "Relevant Medical Conditions")]
        public string Relevant_Medical_Conditions { get; set; }

        [Column("Any Other Information")]
        [Display(Name = "Any Other Information")]
        public string Any_Other_Information { get; set; }

        public bool TB { get; set; }

        [Column("TB Date", TypeName = "date")]
        [Display(Name = "Date Patient Had TB")]
        [DataType(DataType.Date)]
        public DateTime? TB_Date { get; set; }

        [Column("TB Treatment")]
        [Display(Name = "TB Treatment")]
        public string TB_Treatment { get; set; }

        [Column("TB Status")]
        [Display(Name = "TB Status")]
        [StringLength(50)]
        public string TB_Status { get; set; }

        [Column("Cryptococcal Meningitis")]
        [Display(Name = "Care Entry Point")]
        public bool Cryptococcal_Meningitis { get; set; }

        [Column("CM Date", TypeName = "date")]
        [Display(Name = "Date Patient Had Cryptococcal Meningitis")]
        [DataType(DataType.Date)]
        public DateTime? CM_Date { get; set; }

        [Column("CM Treatment")]
        [Display(Name = "Cryptococcal Meningitis Treatment")]
        public string CM_Treatment { get; set; }

        [Column("CM Status")]
        [Display(Name = "Cryptococcal Meningitis Status")]
        [StringLength(50)]
        public string CM_Status { get; set; }

        [Column("Bacterial Meningitis")]
        [Display(Name = "Bacterial Meningitis")]
        public bool Bacterial_Meningitis { get; set; }

        [Column("BM Date", TypeName = "date")]
        [Display(Name = "Date Patient Had Bacterial Meningitis")]
        [DataType(DataType.Date)]
        public DateTime? BM_Date { get; set; }

        [Column("BM Treatment")]
        [Display(Name = "Bacterial Meningitis Treatment")]
        public string BM_Treatment { get; set; }

        [Column("BM Status")]
        [StringLength(50)]
        [Display(Name = "Bacterial Meningitis Status")]
        public string BM_Status { get; set; }

        [Column("Oral Candidiasis")]
        [Display(Name = "Oral Candidiasis")]
        public bool Oral_Candidiasis { get; set; }

        [Column("OC Date", TypeName = "date")]
        [Display(Name = "Date Patient Had Oral Candidiasis")]
        [DataType(DataType.Date)]
        public DateTime? OC_Date { get; set; }

        [Column("OC Treatment")]
        [Display(Name = "Oral Candidiasis Treatment")]
        public string OC_Treatment { get; set; }

        [Column("OC Status")]
        [StringLength(50)]
        [Display(Name = "Oral Candidiasis Status")]
        public string OC_Status { get; set; }

        [Column("Osephageal  Candidiasis")]
        [Display(Name = "Osephageal  Candidiasis")]
        public bool Osephageal__Candidiasis { get; set; }

        [Column("Candidiasis Date", TypeName = "date")]
        [Display(Name = "Date Patient Had Osephageal  Candidiasis")]
        [DataType(DataType.Date)]
        public DateTime? Candidiasis_Date { get; set; }

        [Column("Candidiasis Treatment")]
        [Display(Name = "Osephageal  Candidiasis Treatment")]
        public string Candidiasis_Treatment { get; set; }

        [Column("Candidiasis Status")]
        [Display(Name = "Osephageal  Candidiasis Status")]
        [StringLength(50)]
        public string Candidiasis_Status { get; set; }

        public bool Syphilis { get; set; }

        [Column("Syphilis Date", TypeName = "date")]
        [Display(Name = "Date Patient Had Syphilis")]
        [DataType(DataType.Date)]
        public DateTime? Syphilis_Date { get; set; }

        [Column("Syphilis Treatment")]
        [Display(Name = "Syphilis Treatment")]
        public string Syphilis_Treatment { get; set; }

        [Column("Syphilis Status")]
        [Display(Name = "Syphilis Status")]
        [StringLength(50)]
        public string Syphilis_Status { get; set; }

        public bool Chlamydia { get; set; }

        [Column("Chlamydia Date", TypeName = "date")]
        [Display(Name = "Date Patient Had Chlamydia")]
        [DataType(DataType.Date)]
        public DateTime? Chlamydia_Date { get; set; }

        [Column("Chlamydia Treatment")]
        [Display(Name = "Chlamydia Treatment")]
        public string Chlamydia_Treatment { get; set; }

        [Column("Chlamydia Status")]
        [Display(Name = "Chlamydia Status")]
        [StringLength(50)]
        public string Chlamydia_Status { get; set; }

        public bool Gonorrhea { get; set; }

        [Column("Gonorrhea Date", TypeName = "date")]
        [Display(Name = "Date Patient Had Gonorrhea")]
        [DataType(DataType.Date)]
        public DateTime? Gonorrhea_Date { get; set; }

        [Column("Gonorrhea Treatment")]
        [Display(Name = "Gonorrhea Treatment")]
        public string Gonorrhea_Treatment { get; set; }

        [Column("Gonorrhea Status")]
        [Display(Name = "Gonorrhea Status")]
        [StringLength(50)]
        public string Gonorrhea_Status { get; set; }

        [Column("Full Name")]
        public string Full_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COHORT> COHORTs { get; set; }

        public virtual Demographic Demographic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Exposed_Infant> Exposed_Infant { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family_Member> Family_Member { get; set; }

        public virtual Health_Center Health_Center { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sexual_Partner> Sexual_Partner { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
