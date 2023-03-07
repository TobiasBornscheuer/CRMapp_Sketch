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
    public class SettingsPageViewModel : BaseViewModel
    {
        // Constructor
        public SettingsPageViewModel()
        {
            // initialize values
        }

        // Fields

        // Commands
        public ICommand LogoutCommand => new Command(Logout);
        private async void Logout()
        {
            var userinput = await App.Current.MainPage.DisplayActionSheet("Warning", "log out", "Cancel", "Do you want to log out?");
            if (userinput == "Cancel")
                return;
            else if (userinput == "log out")
            {
                Application.Current.MainPage = new NavigationPage(new LoginPage());
                await App.Current.MainPage.Navigation.PopToRootAsync();
            }
        }

        public ICommand DeleteLoginDataCommand => new Command(DeleteLoginData);
        private async void DeleteLoginData()
        {
            bool a = Xamarin.Essentials.SecureStorage.Remove(SS_Keys.password);
            bool b = Xamarin.Essentials.SecureStorage.Remove(SS_Keys.username);
            if (a && b)
            {
                await App.Current.MainPage.DisplayAlert("", "Your Login Data was deleted succesfully", "OK");
            }
            else
                await App.Current.MainPage.DisplayAlert("Error", "Your Login Data was not deleted succesfully", "OK");
        }

    }
}
