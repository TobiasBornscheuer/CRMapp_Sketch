using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DLKapp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Xamarin.Essentials.SecureStorage.GetAsync(SS_Keys.username).Result != null &&
                Xamarin.Essentials.SecureStorage.GetAsync(SS_Keys.password).Result != null)
            {
                MainPage = new NavigationPage(new MainPage());
            }
            else
            {
                MainPage = new NavigationPage(new LoginPage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
