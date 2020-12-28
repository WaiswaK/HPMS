using SQLite;
using System;

namespace App.Database
{
    [Table("User")]
    public class User
    {
        [PrimaryKey]
        public string Username { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }

        //Used For Dashboard Data
        public string ART_CARE_COHORT { get; set; }
        public string Current_Drugs { get; set; }
        public DateTime? Date_Next_Visit { get; set; }
        public string Fullnames { get; set; }
        public string Profile_photo { get; set; }
        public string TB_Regimen { get; set; }
        public string WHO_HIV_Stage { get; set; }
    }
}
