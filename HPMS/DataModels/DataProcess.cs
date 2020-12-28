using HPMS.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace HPMS.DataModels
{
    public class DataProcess
    {
        private static readonly Models.HPMS db = new Models.HPMS();

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
                        Viral_Load = ZeroNull(_result.Viral_Load),
                        Blood_pressure___Diastolic = ZeroNull(_result.Blood_pressure___Diastolic),
                        Blood_pressure___Systolic = ZeroNull(_result.Blood_pressure___Systolic),
                        Blood_Sugar = ZeroNull(_result.Blood_Sugar),
                        CD4_Count = ZeroNull(_result.CD4_Count),
                        Date_Next_Visit = _result.Date_Next_Visit,
                        MUAC_SCORE = ZeroNull(_result.MUAC_SCORE),
                        Visit_Date = _result.Visit_Date,
                        Visit_ID = _result.Visit_ID,
                        Weight = ZeroNull(_result.Weight),
                        Weight_Score = ZeroNull(_result.Weight_Score)
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
                var query = db.Patients.Where(c => c.NIN == _nin).Single();
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
                var query = db.AspNetUsers.Where(c => c.Email == _username).Single();
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
        public static bool ComparePatientWithNIN(string nin, string PID)
        {
            try
            {
                var query = db.Patients.Where(c => c.PID == PID).Single();
                if (nin == query.NIN)
                    return true;
                else return false;
            }
            catch
            {
                return false;
            }
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
        public static string ImageOrName(string nin, string content)
        {
            string fullname = string.Empty;
            string imagepath = string.Empty;
            try
            {
                var query = db.Demographics.Where(c => c.NIN == nin).FirstOrDefault();
                fullname = query.Full_Name;
                imagepath = query.ImagePath;
            }
            catch
            {
            }
            if (content == "Name")
                return fullname;
            else
            {
                return imagepath;
            }
        }
        public static ICollection NotSet(string Category)
        {
            List<Demographic> people = db.Demographics.ToList();
            ICollection final = people.ToList();
            if (Category == "Patient")
            {
                try
                {
                    var query = db.Patients.ToList();
                    foreach (var patient in query)
                    {
                        var find = db.Demographics.Where(c => c.NIN == patient.NIN).FirstOrDefault();
                        people.Remove(find);
                    }
                    final = people.ToList();
                }
                catch
                {

                }
            }
            if (Category == "Staff")
            {
                try
                {
                    var query = db.Staffs.ToList();
                    foreach (var staff in query)
                    {
                        var find = db.Demographics.Where(c => c.NIN == staff.NIN).FirstOrDefault();
                        people.Remove(find);
                    }
                    final = people.ToList();
                }
                catch
                {

                }
            }
            return final;
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
                var query = db.Visits.Where(c => c.PID.Equals(PID)).ToList().LastOrDefault();
                dashboard.Current_Drugs = query.ARV_Drugs;
                dashboard.Date_Next_Visit = query.Date_Next_Visit;
                dashboard.WHO_HIV_Stage = query.Clinical_Stage;
                dashboard.Diet_Chart = query.DC; //To be converted
                dashboard.Health_Tip = query.HT; //To be converted

                //Cohort info in dashboard
                var cohort = db.COHORTs.Where(c => c.PID.Equals(PID)).ToList().LastOrDefault();
                dashboard.ART_CARE_COHORT = cohort.COHORT_ID;

                //Substitution data
                var susbstitution = db.Substitutions.Where(c => c.PID.Equals(PID)).ToList().LastOrDefault();
                dashboard.TB_Regimen = susbstitution.Regimen;

                //Data from demograpic
                string userID = GetID(_username);
                var dem = db.Demographics.Where(c => c.Id.Equals(userID)).FirstOrDefault();
                dashboard.Profile_photo = dem.ImagePath;
                dashboard.Username = _username;
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
            return int.Parse(datalist.Last()) + 1;
        }
        public static string RemoveSpace(string _name)
        {
            if (_name != null)
            {
                string name = _name;
                name.Replace("  ", " ");
                return name;
            }
            else
                return string.Empty;
        }
        public static string Replace_(string word)
        {
            string final = word;
            if (word != null)
            {
                final.Replace("_", " ");
                return final;
            }
            else
                return string.Empty;
        }
        public static bool Exists(string _nin, string Category)
        {
            bool found = false;
            if (Category == "Patient")
            {
                try
                {
                    var query = db.Patients.Where(c => c.NIN == _nin).ToList();
                    if (query.Count == 0)
                        found = false;
                    else found = true;
                }
                catch
                {

                }
            }
            if (Category == "Staff")
            {
                try
                {
                    var query = db.Staffs.Where(c => c.NIN == _nin).ToList();
                    if (query.Count == 0)
                        found = false;
                    else found = true;
                }
                catch
                {

                }
            }
            return found;
        }
        private static decimal? ZeroNull(decimal? num)
        {
            if (num ==null) 
            {
                return 0;
            }
            else
            {
                return num;
            }
        }
    }
}