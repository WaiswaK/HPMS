using System;
using System.Collections.Generic;
using System.Linq;

namespace HPMS.DataModels
{
    public class DataProcess
    {
        private static Models.HPMS db = new Models.HPMS();

        #region Patient Processing
        public static List<ResultData> Patient_Visits(string _username)
        {
            List<ResultData> _patient_visits = new List<ResultData>();
            string PID = GetPID(GetNIN(GetID(_username)));
            try
            {
                var query = db.Visits.Where(c => c.PID.Equals(PID)).ToList();
                foreach (var _result in query)
                {
                    ResultData visit = new ResultData
                    {
                        PID = _result.PID,
                        Viral_Load = _result.Viral_Load,
                        Blood_pressure___Diastolic = _result.Blood_pressure___Diastolic,
                        Blood_pressure___Systolic = _result.Blood_pressure___Systolic,
                        Blood_Sugar = _result.Blood_Sugar,
                        CD4_Count = _result.CD4_Count,
                        Date_Next_Visit = _result.Date_Next_Visit,
                        MUAC_SCORE = _result.MUAC_SCORE,
                        Visit_Date = _result.Visit_Date,
                        Visit_ID = _result.Visit_ID,
                        Weight = _result.Weight,
                        Weight_Score = _result.Weight_Score
                    };
                    _patient_visits.Add(visit);           
                }
            }
            catch
            {
            }
            return _patient_visits;
        }
        private static string GetPID(string _nin)
        {
            string PID = string.Empty;
            try
            {
                var query = db.Patients.Where(c=> c.NIN == _nin).Single();
                PID = query.PID;
            }
            catch
            {

            }
            return PID;
        }
        private static string GetID(string _username)
        {
            string id = string.Empty;
            try
            {
                var query = db.AspNetUsers.Where(c => c.UserName == _username).Single();
                id = query.Id;
            }
            catch
            {

            }

            return id;
        }
        private static string GetNIN(string _id)
        {
            string NIN = string.Empty;
            try
            {
                var query = db.Demographics.Where(c => c.Id == _id).Single();
                NIN = query.NIN;
            }
            catch
            {

            }
            return NIN;
        }
        #endregion

        #region Demographic Processing
        public static bool Exists(string _id)
        {
            bool found = false;
            try
            {
                var query = db.Demographics.Where(c => c.Id == _id).ToList();
                if (query.Count == 0)
                    found = false;
                else found = true;
            }
            catch
            {

            }
            return found;
        }  
        #endregion

        #region Dashboard Processing
        public static DashData Dashboard(string _username)
        {
            DashData dashboard = new DashData();
            string PID = GetPID(GetNIN(GetID(_username)));
            try
            {
                //Visit info in dashboard
                var query = db.Visits.Where(c => c.PID.Equals(PID)).Last();
                dashboard.Current_Drugs = query.ARV_Drugs;
                dashboard.Date_Next_Visit = query.Date_Next_Visit;
                dashboard.WHO_HIV_Stage = query.Clinical_Stage;

                //Cohort info in dashboard
                var cohort = db.COHORTs.Where(c => c.PID.Equals(PID)).Last();
                dashboard.ART_CARE_COHORT = cohort.COHORT_ID;

                //Substitution data
                var susbstitution = db.Substitutions.Where(c => c.PID.Equals(PID)).Last();
                dashboard.TB_Regimen = susbstitution.Regimen;

                //Data from demograpic
                var dem = db.Demographics.Where(c => c.Id.Equals(PID)).Last();
                dashboard.Username = _username;
                dashboard.Profile_photo = dem.ImagePath;
                dashboard.Fullnames = RemoveSpace(dem.Given_Name + " " + dem.Midle_Name + " " + dem.Family_Name);               
            }
            catch
            {

            }
            return dashboard;
        }
        #endregion

        public static int NextNumber(string data)
        {
            char[] delimiter = { '-' };
            string[] datasplit = data.Split(delimiter);
            List<string> datalist = datasplit.ToList();
            return Int32.Parse(datalist.Last()) + 1;
        }
        public static string RemoveSpace(string _name)
        {
            string name = _name;
            name.Replace("  ", " ");
            return name;
        }
        public static string Replace_(string word)
        {
            string final = word;
            final.Replace("_", " ");
            return final;
        }
    }
}