using App.Database;
using App.Services;
using System;
using System.Threading.Tasks;

namespace App.ViewModels
{
    class HomeViewModel
    {
        public string ART_CARE_COHORT { get; set; }
        public string Current_Drugs { get; set; }
        public DateTime? Date_Next_Visit { get; set; }
        public string Fullnames { get; set; }
        public string Profile_photo { get; set; }
        public string TB_Regimen { get; set; }
        public string WHO_HIV_Stage { get; set; }
        public string Username { get; set; }
        public User ActiveUser { get; set; }

        public HomeViewModel()
        {
            ActiveUser = Services.Database.UserDetails(Services.Database.GetActiveUser());
            Task.Run(async () =>
            {
                await UpdatedataAsync(ActiveUser);
            });
            Username = ActiveUser.Username;
            Fullnames = ActiveUser.Fullnames;
            TB_Regimen = ActiveUser.TB_Regimen;
            ART_CARE_COHORT = ActiveUser.ART_CARE_COHORT;
            Current_Drugs = ActiveUser.Current_Drugs;
            WHO_HIV_Stage = ActiveUser.WHO_HIV_Stage;
            Profile_photo = ActiveUser.Profile_photo;
            Date_Next_Visit = ActiveUser.Date_Next_Visit;
        }
        private static async Task UpdatedataAsync(User user)
        {
            Services.Database.UpdateUser(await Json.GetDashboard(user.Username));          
        }
    }
}
