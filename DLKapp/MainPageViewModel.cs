using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DLKapp
{
    public class MainPageViewModel : BaseViewModel
    {
        // Constructor
        public MainPageViewModel() 
        {
            TableDataObjectList = new ObservableCollection<TableDataObject>()
            {
                new TableDataObject("anne", "DBSV"),
                new TableDataObject("anton", "BFW"),
                new TableDataObject("simon", "SPD"),
                new TableDataObject("robert", "BND"),
                new TableDataObject("sibille", "AKW"),
                new TableDataObject("monika", "LMG"),
                new TableDataObject("axel", "ALN"),
                new TableDataObject("erhardt", "BCP"),
                new TableDataObject("sabrina", "LKC"),
                new TableDataObject("emil", "TDC"),
                new TableDataObject("konstanze", "PNL"),
                new TableDataObject("sap", "f"),
                new TableDataObject("papenmeier", "f"),
                new TableDataObject("amazon", "f")
            };
        }

        // Fields
        public ObservableCollection<TableDataObject> TableDataObjectList {get; set;}

        // Commands
        public ICommand SearchCommand => new Command<string>(Search);
        void Search(string query)
        {
            // search logic

        }

        public ICommand GoToOptionsCommand => new Command(GoToOptions);
        async void GoToOptions() 
        {
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }


    }
}
