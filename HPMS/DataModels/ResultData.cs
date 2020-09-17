using System;
using System.Diagnostics;

namespace HPMS.DataModels
{
    public class ResultData
    {
        public string Visit_ID { get; set; }
        public string PID { get; set; }
        public DateTime? Visit_Date { get; set; }
        public DateTime? Date_Next_Visit { get; set; }
        public decimal? MUAC_SCORE { get; set; }
        public decimal? Weight { get; set; }
        public string Weight_Score { get; set; }
        public decimal? Blood_pressure___Systolic { get; set; }
        public decimal? Blood_pressure___Diastolic { get; set; }
        public decimal? Blood_Sugar { get; set; }
        public decimal? CD4_Count { get; set; }
        public decimal? Viral_Load { get; set; }
    }

    public class DashData
    {
        public string Current_Drugs { get; set; } //ARV Drugs in visit last
        public DateTime? Date_Next_Visit { get; set; } // in visit last
        public string WHO_HIV_Stage { get; set; } // visit last
        public string ART_CARE_COHORT { get; set; } //Under Cohort table
        public string TB_Regimen { get; set; } // Under substitutions
        public string Profile_photo { get; set; } //Under Demographic
        public string Username { get; set; } // direct from data
        public string Fullnames { get; set; } // from demographic
        public string Health_Tip { get; set; } //visit last
        public string Diet_Chart { get; set; } //visit last
        //public string Documet_links { get; set; } //All visits of patient
    }

    public class AppointmentData
    {
        //public string Appointment_ID { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public DateTime Appointment_Date { get; set; }
        public TimeSpan Appointment_Time { get; set; }
        //public bool Accepted { get; set; }
        public bool? Rescheduled { get; set; }
        public DateTime? Rescheduled_Date { get; set; }
        public TimeSpan? Rescheduled_Time { get; set; }
        //public bool Completed { get; set; }
    }
}