using App.Services;
using App.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : MasterDetailPage
    {
        public Dashboard()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is DashboardMenuItem item))
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            #region Page Selection
            if (page.Title == "Settings" || page.Title == "About")
            {
                Detail = new NavigationPage(page)
                {
                    BarBackgroundColor = Color.Blue,
                    BarTextColor = Color.White
                };
            }
            else
            {
                string connected = await Plugin.Connectivity.CrossConnectivity.Current.
                IsRemoteReachable(Constants.baseUrl, Constants.port) ? "Reachable" : "Not reachable";

                string username = Services.Database.UserDetails(Services.Database.GetActiveUser()).Username;

                if (connected == "Reachable")
                {
                    if(page.Title == "Home")
                    {
                        Detail = new NavigationPage(page)
                        {
                            BindingContext = new HomeViewModel(),
                            BarBackgroundColor = Color.Blue,
                            BarTextColor = Color.White
                        };
                    }
                    if(page.Title == "Weight")
                    {
                        Detail = new NavigationPage(page)
                        {
                            BindingContext = new GraphViewModel("Weight", username),
                            BarBackgroundColor = Color.Blue,
                            BarTextColor = Color.White
                        };
                    }
                    if (page.Title == "MUAC Score")
                    {
                        Detail = new NavigationPage(page)
                        {
                            BindingContext = new GraphViewModel("MUAC_SCORE", username),
                            BarBackgroundColor = Color.Blue,
                            BarTextColor = Color.White
                        };
                    }
                    if (page.Title == "Blood Sugar")
                    {
                        Detail = new NavigationPage(page)
                        {
                            BindingContext = new GraphViewModel("Blood_Sugar", username),
                            BarBackgroundColor = Color.Blue,
                            BarTextColor = Color.White
                        };
                    }
                    if (page.Title == "HIV viral load")
                    {
                        Detail = new NavigationPage(page)
                        {
                            BindingContext = new GraphViewModel("Viral_Load", username),
                            BarBackgroundColor = Color.Blue,
                            BarTextColor = Color.White
                        };
                    }
                }
                else
                {
                    await DisplayAlert(Message.Internet_Header, Message.Connection_Fail, Message.Ok);
                }
            }
            #endregion
            //Detail = new NavigationPage(page);
            IsPresented = false;
            MasterPage.ListView.SelectedItem = null;
        }
    }
}