using System.Collections.Generic;
using System.Linq;

namespace HPMS.DataModels
{
    public class VisitDataProcess
    {
        private static Models.HPMS db = new Models.HPMS();
        public static List<ResultData> Patient_Visits(string _nin)
        {
            List<ResultData> _patient_visits = new List<ResultData>();
            string PID = GetPID(_nin);
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
    }
}