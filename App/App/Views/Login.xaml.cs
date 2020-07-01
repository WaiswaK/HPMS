using App.Database;
using App.Models;
using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }
        void OnLoginButtonClicked(object sender, EventArgs e)
        {
            IsBusy = true;
            Constants.InitializeDatabase();
            string username = Constants.NullRemove(email_tb.Text);
            string code = Constants.NullRemove(password_tb.Text);
            LoginAction(username, code);
        }

        private void Register_btn_Clicked(object sender, EventArgs e)
        {
            host_field.IsVisible = true;
            port_field.IsVisible = true;
            SaveBtn.IsVisible = true;
            email_tb.IsVisible = false;
            password_tb.IsVisible = false;
            login_btn.IsVisible = false;
            register_btn.IsVisible = false;
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            if (host_field.Text == null || port_field.Text == null || host_field.Text == string.Empty || port_field.Text == string.Empty)
            {
                DisplayAlert(Message.Server_Header, Message.SettingsIncomplete, Message.Ok);
            }
            else
            {
                using (var db = DependencyService.Get<DependencyInterface.IClientDatabase>().GetConnection())
                {
                    var query = db.Table<Server>().ToList();
                    if (query.Count > 0)
                    {
                        foreach (var result in query)
                        {
                            db.Delete(result);
                        }
                    }
                    db.Insert(new Server()
                    {
                        Host = host_field.Text,
                        Port = Int32.Parse(port_field.Text)
                    });
                }
                DisplayAlert(Message.Server_Header, Message.Server_Message, Message.Ok);
                host_field.IsVisible = false;
                port_field.IsVisible = false;
                SaveBtn.IsVisible = false;
                email_tb.IsVisible = true;
                password_tb.IsVisible = true;
                login_btn.IsVisible = true;

            }
        }

        #region Login Methods
        private async void LoginAction(string username, string password)
        {
            if (username == string.Empty || password == string.Empty)
            {
                await DisplayAlert(Message.Login_Header, Message.NoLoginDetails, Message.Ok);
                LoadingMsg.IsVisible = false;
                IsBusy = false;
            }
            else
            {
                LoadingMsg.IsVisible = true;
                LoadingMsg.Text = Message.Checking_Connection;
                string connected = await Plugin.Connectivity.CrossConnectivity.Current.
                IsRemoteReachable(Constants.baseUrl, Constants.port) ? "Reachable" : "Not reachable";
                if (connected == "Reachable")
                {
                    LoadingMsg.Text = Message.Connection_Established;
                    Authenticate(username, password);
                }
                else
                {
                    await DisplayAlert(Message.Login_Header, Message.Login_Message_Fail, Message.Ok);
                    IsBusy = false;
                    LoadingMsg.IsVisible = false;
                }
            }
        }
        private async void Authenticate(string username, string code)
        {
            LoadingMsg.Text = Message.User_Validation;
            List<User> users = Services.Database.SelectAllUsers();
            LoginTokenResult Token = new LoginTokenResult();
            string error = string.Empty;
            string Token_Result = string.Empty;
            if (users == null)
            {
                Token = Json.GetLoginToken(username, code);
                error = Constants.NullRemove(Token.ErrorDescription);
                Token_Result = Constants.NullRemove(Token.AccessToken);
                if (Token_Result == string.Empty)
                {
                    await DisplayAlert(Message.Login_Header, error, Message.Ok);
                    IsBusy = false;
                    LoadingMsg.IsVisible = false;
                }
                else
                {
                    User user = new User()
                    {
                        User_name = username,
                        Code = code
                    };
                    Services.Database.InsertUser(user);
                    FinalNavigation(user.User_name);
                }
            }
            else
            {
                foreach (var user in users)
                {
                    if (user.User_name.Equals(username) && user.Code.Equals(code))
                    {
                        Token = Json.GetLoginToken(username, code);
                        error = "You have entered an old password, Please enter the current password";
                        Token_Result = Constants.NullRemove(Token.AccessToken);
                        if (Token_Result == string.Empty)
                        {
                            await DisplayAlert(Message.Login_Header, error, Message.Ok);
                            IsBusy = false;
                            LoadingMsg.IsVisible = false;
                        }
                        else
                        {
                            FinalNavigation(user.User_name);
                        }
                    }
                }
            }
        }
        private async void FinalNavigation(string user)
        {
            Services.Database.UpdateUser(true, user);
            Navigation.InsertPageBefore(new Dashboard()
            {
                BindingContext = new ViewModels.DashboardMasterViewModel()
            }
                , this);
            await Navigation.PopAsync();
        }
        #endregion
       
    }
}