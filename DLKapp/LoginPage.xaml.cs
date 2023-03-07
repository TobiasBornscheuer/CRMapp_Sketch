using DLKapp;
using System;
using Xamarin.Forms;

namespace DLKapp
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}

/*
==> LoginPage before MVVM was implemented 

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();

        username_entryfield.Text = Xamarin.Essentials.SecureStorage.GetAsync(SS_Keys.username).Result;
        password_entryfield.Text = Xamarin.Essentials.SecureStorage.GetAsync(SS_Keys.password).Result;
    }
    //Bei Instanzieren der Page über den LogOut-Button wird sie als MainPage festgelegt.
    private async void loginrequest_button_Clicked(object sender, EventArgs e)
    {
        // Hier die Daten gegen die Datenbank prüfen und speichern bei falschen Daten unterbinden
        if (save_logindata_checkbox.IsChecked && username_entryfield.Text != null && password_entryfield.Text != null)
        {
            await Xamarin.Essentials.SecureStorage.SetAsync(SS_Keys.password, password_entryfield.Text);
            await Xamarin.Essentials.SecureStorage.SetAsync(SS_Keys.username, username_entryfield.Text);
            Application.Current.MainPage = new NavigationPage(new MainPage());
            await Navigation.PopToRootAsync();
        }
        // Hier die Daten gegen die Datenbank prüfen
        else if (username_entryfield.Text != null && password_entryfield.Text != null)
        {
            Application.Current.MainPage = new NavigationPage(new MainPage());
            await Navigation.PopToRootAsync();
        }
        else
        {
            await DisplayAlert("Error", "The Login Data you provided is not valid", "Back");
        }
    }
}
*/