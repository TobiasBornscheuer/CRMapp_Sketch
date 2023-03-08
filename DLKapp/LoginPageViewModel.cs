using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DLKapp
{
    public class LoginPageViewModel : BaseViewModel
    {
        // Constructor
        public LoginPageViewModel()
        {
            // Instantiate the fields with the data from the SecureStorage. Checkbox unchecked by default.
            Username = Xamarin.Essentials.SecureStorage.GetAsync(SS_Keys.username).Result;
            Password = Xamarin.Essentials.SecureStorage.GetAsync(SS_Keys.password).Result;
            SaveLoginData = false;
        }

        // Fields
        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                SetProperty(ref _username, value);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                SetProperty(ref _password, value);
            }
        }

        private bool _saveLoginData;
        public bool SaveLoginData
        {
            get
            {
                return _saveLoginData;
            }
            set
            {
                SetProperty(ref _saveLoginData, value);
            }
        }

        // Commands
        public ICommand LoginRequestCommand => new Command(LoginRequest);
         private async void LoginRequest()
        {
            if (SaveLoginData == true && Username != null && Password != null)
            {
                await Xamarin.Essentials.SecureStorage.SetAsync(SS_Keys.password, Password);
                await Xamarin.Essentials.SecureStorage.SetAsync(SS_Keys.username, Username);
                Application.Current.MainPage = new NavigationPage(new MainPage());
                await App.Current.MainPage.Navigation.PopToRootAsync(); // delete LoginPageInstance and set MainPage as RootPage, to keep NavigationStack clean.
            }
            else if (Username != null && Password != null)
            {
                Application.Current.MainPage = new NavigationPage(new MainPage());
                await App.Current.MainPage.Navigation.PopToRootAsync(); // delete LoginPageInstance and set MainPage as RootPage, to keep NavigationStack clean.
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "The Login Data you provided is not valid", "Back");
            }
        }
    }
}
