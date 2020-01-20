namespace HPMS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Visit")]
    public partial class Visit
    {
        [Key]
        [Column("Visit ID")]
        [Display(Name = "Visit")]
        [StringLength(50)]
        public string Visit_ID { get; set; }

        [StringLength(50)]
        [Display(Name = "Patient")]
        public string PID { get; set; }

        [Column("Visit Date", TypeName = "date")]
        [Display(Name = "Visit Date")]
        public DateTime? Visit_Date { get; set; }

        [Column("Date Next Visit", TypeName = "date")]
        [Display(Name = "Date Next Visit")]
        public DateTime? Date_Next_Visit { get; set; }

        [Column("Date of Birth", TypeName = "date")]
        [Display(Name = "Date of Birth")]
        public DateTime? Date_of_Birth { get; set; }

        [Column("Nutrition Assessment")]
        [Display(Name = "Nutrition Assessment")]
        public string Nutrition_Assessment { get; set; }

        [Column("Pregnancy Status")]
        [Display(Name = "Pregnancy Status")]
        public bool? Pregnancy_Status { get; set; }

        public double? Gestation { get; set; }

        [Column(TypeName = "text")]
        public string FP { get; set; }

        [Column("FP Method")]
        [Display(Name = "FP Method")]
        public string FP_Method { get; set; }

        [Column("CaCx Screening")]
        [Display(Name = "CaCx Screening")]
        public string CaCx_Screening { get; set; }

        [Column("TB Status")]
        [Display(Name = "TB Status")]
        public bool? TB_Status { get; set; }

        public bool? TPT { get; set; }

        [Column("TPT Effects")]
        [Display(Name = "TPT Effects")]
        public string TPT_Effects { get; set; }

        public string Diagnosis { get; set; }

        [Column("ART Effects")]
        [Display(Name = "ART Effects")]
        public string ART_Effects { get; set; }

        [Column("Hep Test")]
        [Display(Name = "Hep Test")]
        public bool? Hep_Test { get; set; }

        [Column("Hep Result")]
        [Display(Name = "Hep Result")]
        public string Hep_Result { get; set; }

        [Column("Syphilis Status")]
        [Display(Name = "Syphilis Status")]
        public bool? Syphilis_Status { get; set; }

        public string CTX { get; set; }

        [Column("Other Meds")]
        [Display(Name = "Other Meds")]
        public string Other_Meds { get; set; }

        [Column("ARV Drugs")]
        [Display(Name = "ARV Drugs")]
        public string ARV_Drugs { get; set; }

        public string Fluconazole { get; set; }

        [Column("Tests and Investigations")]
        [Display(Name = "Tests and Investigations")]
        public string Tests_and_Investigations { get; set; }

        [Column("DSD Model")]
        [Display(Name = "DSD Model")]
        public string DSD_Model { get; set; }

        [StringLength(50)]
        public string SID { get; set; }

        [Column("MUAC SCORE")]
        [Display(Name = "MUAC SCORE")]
        public decimal? MUAC_SCORE { get; set; }

        public decimal? Weight { get; set; }

        public decimal? Height { get; set; }

        [Column("Weight Score")]
        [Display(Name = "Weight Score")]
        public string Weight_Score { get; set; }

        [Column("Height Score")]
        [Display(Name = "Height Score")]
        public string Height_Score { get; set; }

        [Column("BMI Score")]
        [Display(Name = "BMI Score")]
        public decimal? BMI_Score { get; set; }

        [Column("Blood pressure - Systolic")]
        [Display(Name = "Blood pressure - Systolic")]
        public decimal? Blood_pressure___Systolic { get; set; }

        [Column("Blood pressure - Diastolic")]
        [Display(Name = "Blood pressure - Diastolic")]
        public decimal? Blood_pressure___Diastolic { get; set; }

        [Column("Blood Sugar")]
        [Display(Name = "Blood Sugar")]
        public decimal? Blood_Sugar { get; set; }

        public decimal? Temperature { get; set; }

        [Column("Tobacco Use")]
        [Display(Name = "Tobacco Use")]
        [StringLength(50)]
        public string Tobacco_Use { get; set; }

        [Column("CD4 Count", TypeName = "numeric")]
        [Display(Name = "CD4 Count")]
        public decimal? CD4_Count { get; set; }

        [Column("Clinical Stage")]
        [Display(Name = "Clinical Stage")]
        [StringLength(50)]
        public string Clinical_Stage { get; set; }

        [Column("Viral Load", TypeName = "numeric")]
        [Display(Name = "Viral Load")]
        public decimal? Viral_Load { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
