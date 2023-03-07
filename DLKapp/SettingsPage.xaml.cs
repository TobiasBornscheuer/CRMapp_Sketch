using DLKapp;
using System;

using Xamarin.Forms;

namespace DLKapp
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
    }
}


/*
==> SettingsPage before MVVM was implemented 

public partial class SettingsPage : ContentPage
{
    public SettingsPage()
    {
        InitializeComponent();
    }

    private async void GoToLoginscreen_button_Clicked(object sender, EventArgs e)
    {
        var userinput = await DisplayActionSheet("Warning", "log out", "Cancel", "Do you want to log out?");
        if (userinput == "Cancel")
            return;
        else if (userinput == "log out")
        {
            Application.Current.MainPage = new NavigationPage(new LoginPage());
            await Navigation.PopToRootAsync();
        }
    }

    private async void DeleteLoginData_button_Clicked(object sender, EventArgs e)
    {
        bool a = Xamarin.Essentials.SecureStorage.Remove(SS_Keys.password);
        bool b = Xamarin.Essentials.SecureStorage.Remove(SS_Keys.username);
        if (a && b)
        {
            await DisplayAlert("", "Your Login Data was deleted succesfully", "OK");
        }
        else
            await DisplayAlert("Error", "Your Login Data was not deleted succesfully", "OK");


    }
}
*/