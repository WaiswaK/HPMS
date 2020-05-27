using System;

namespace App.Models
{
    public class Visit
    {
        public string Visit_ID { get; set; }
        public string PID { get; set; }
        public DateTime Visit_Date { get; set; }
        public DateTime Date_Next_Visit { get; set; }
        public decimal MUAC_SCORE { get; set; }
        public decimal Weight { get; set; }
        public string Weight_Score { get; set; }
        public decimal Blood_pressure___Systolic { get; set; }
        public decimal Blood_pressure___Diastolic { get; set; }
        public decimal Blood_Sugar { get; set; }
        public decimal CD4_Count { get; set; }
        public decimal Viral_Load { get; set; }
    }
}
