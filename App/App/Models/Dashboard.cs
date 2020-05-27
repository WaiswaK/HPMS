using System;

namespace App.Models
{
    class Dashboard
    {
        public string Current_Drugs { get; set; } 
        public DateTime? Date_Next_Visit { get; set; } 
        public string WHO_HIV_Stage { get; set; }
        public string ART_CARE_COHORT { get; set; } 
        public string TB_Regimen { get; set; } 
        public string Profile_photo { get; set; } 
        public string Username { get; set; } 
        public string Fullnames { get; set; } 
    }
}
