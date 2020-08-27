using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App.Views;
using App.Services;
using App.ViewModels;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            // if (Device.RuntimePlatform == Device.Android)
            //{
               //MainPage = new Splash();
            // }
            //else
            //{
            MainPage = new NavigationPage(
                            new Dashboard()
                            {
                                BindingContext = new DashboardMasterViewModel(),
                                IsPresented = true
                            })
            {
                BarBackgroundColor = Color.Blue,
                BarTextColor = Color.White
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Constants.InitializeDatabase();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
