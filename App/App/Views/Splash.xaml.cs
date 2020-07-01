using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Splash : ContentPage
	{
		public Splash ()
		{
			InitializeComponent ();
		}
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // await a new task
            await Task.Factory.StartNew(async () => {

                // delay for a few seconds on the splash screen
                await Task.Delay(1500);

                var navPage = new NavigationPage();
                if (Services.Database.GetActiveUser() == string.Empty)
                {
                    navPage = new NavigationPage(new Login())
                    {
                        //BarBackgroundColor = Color.Blue
                    };
                }
                else
                {
                    navPage = new NavigationPage(
                                new Dashboard()
                                {
                                    //BindingContext = new MasterViewModel(),
                                    IsPresented = true
                                })
                    {
                        BarBackgroundColor = Color.Blue,
                        BarTextColor = Color.White
                    };
                }
                // on the main UI thread, set the MainPage to the navPage
                Device.BeginInvokeOnMainThread(() => {
                    Application.Current.MainPage = navPage;
                });
            });
        }
    }
}