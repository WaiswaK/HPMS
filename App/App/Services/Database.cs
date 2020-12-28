using App.Database;
using App.DependencyInterface;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace App.Services
{
    public class Database
    {
        #region User
        public static List<User> SelectAllUsers()
        {
            List<User> users = new List<User>();
            List<User> nullUser = null;
            int count = 0;
            using (var db = DependencyService.Get<IClientDatabase>().GetConnection())
            {
                var query = (db.Table<User>().ToList());
                users = query;
                count = query.Count;
            }
            if (count > 0)
                return users;
            else
                return nullUser;
        }
        public static User UserDetails(string user)
        {
            using (var db = DependencyService.Get<IClientDatabase>().GetConnection())
            {
                var query = (db.Table<User>().Where(c => c.Username == user)).Single();
                return new User()
                {
                    Active = query.Active,
                    Code = query.Code,
                    Username = query.Username,
                    ART_CARE_COHORT = query.ART_CARE_COHORT,
                    Current_Drugs = query.Current_Drugs,
                    Date_Next_Visit = query.Date_Next_Visit,
                    Fullnames = query.Fullnames,
                    Profile_photo = query.Profile_photo,
                    TB_Regimen = query.TB_Regimen,
                    WHO_HIV_Stage = query.WHO_HIV_Stage
                };
            }
        }
        public static string GetActiveUser()
        {
            List<User> users = SelectAllUsers();
            string active = string.Empty;
            if (users == null)
            {
                return active;
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.Active == true)
                        active = user.Username;
                    else
                    {
                        ;
                    }
                }
                return active;
            }
        }
        public static void UpdateUser(bool active, string user)
        {
            User current = UserDetails(user);
            User final = new User()
            {
                Active = active,
                Code = current.Code,
                Username = current.Username
            };
            var db = DependencyService.Get<IClientDatabase>().GetConnection();
            db.Update(final);
        }
        public static void UpdateUser(User user)
        {
            var db = DependencyService.Get<IClientDatabase>().GetConnection();
            db.Update(user);
        }
        public static void InsertUser(User user)
        {
            var db = DependencyService.Get<IClientDatabase>().GetConnection();
            try
            {
                db.Insert(new User()
                {
                    Username = user.Username,
                    Code = user.Code,
                    Active = true
                });
            }
            catch
            {
            }
        }
        #endregion

        #region Visits
        public static List<Visit> GetVisits(string user)
        {
            List<Visit> visits = new List<Visit>();
            List<Visit> nullvist = null;
            int count = 0;
            using (var db = DependencyService.Get<IClientDatabase>().GetConnection())
            {
                visits = (db.Table<Visit>().Where(c => c.Username == user).ToList());
                count = visits.Count;
            }
            if (count > 0)
                return visits;
            else
                return nullvist;
        }
        private static void InsertVisit(Visit visit, string user)
        {
            var db = DependencyService.Get<IClientDatabase>().GetConnection();
            try
            {
                db.Insert(new Visit()
                {
                    Visit_ID = visit.Visit_ID,
                    Username = user,
                    MUAC_SCORE = visit.MUAC_SCORE,
                    Blood_pressure___Diastolic = visit.Blood_pressure___Diastolic,
                    Blood_pressure___Systolic = visit.Blood_pressure___Systolic,
                    Blood_Sugar = visit.Blood_Sugar,
                    CD4_Count = visit.CD4_Count,
                    Date_Next_Visit = visit.Date_Next_Visit,
                    PID = visit.PID,
                    Viral_Load = visit.Viral_Load,
                    Visit_Date = visit.Visit_Date,
                    Weight = visit.Weight,
                    Weight_Score = visit.Weight_Score
                }); 
            }
            catch
            {
                
            }
        }
        public static void InsertVisits(List<Visit> visits, string user)
        {
            foreach(var visit in visits)
            {
                InsertVisit(visit, user);
            }
        }
        #endregion
    }
}
