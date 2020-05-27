using App.Models;
using App.Services;
using System;
using System.Threading.Tasks;

namespace App.ViewModels
{
    class HomeViewModel
    {
        public string ART_CARE_COHORT { get; set; }
        public string Current_Drugs { get; set; }
        public DateTime Date_Next_Visit { get; set; }
        public string Fullnames { get; set; }
        public string Profile_photo { get; set; }
        public string TB_Regimen { get; set; }
        public string WHO_HIV_Stage { get; set; }
        public string Username { get; set; }
        public Dashboard DashboardData { get; set; }

        public HomeViewModel()
        {
            GetdataAsync(Username);
            Fullnames = DashboardData.Fullnames;
            TB_Regimen = DashboardData.TB_Regimen;
            ART_CARE_COHORT = DashboardData.ART_CARE_COHORT;
            Current_Drugs = DashboardData.Current_Drugs;
            WHO_HIV_Stage = DashboardData.WHO_HIV_Stage;
            Profile_photo = DashboardData.Profile_photo;
            //Date_Next_Visit = DashboardData.Date_Next_Visit;
        }
        private async Task GetdataAsync(string _username)
        {
            Dashboard _dashboard = await Json.GetDashboard(_username);
        }

    }
}
