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
            // initialize empty ObservableCollection
            TableDataObjectList = new ObservableCollection<TableDataObject>();
        }

        // Fields
        public ObservableCollection<TableDataObject> TableDataObjectList {get; set;}

        // Commands
        public ICommand SearchCommand => new Command<string>(Search);
        void Search(string query)
        {
            var searchterm = query.ToLowerInvariant();
            if (!string.IsNullOrEmpty(searchterm)) 
            {
                if(TableDataObjectList != null)
                    TableDataObjectList.Clear();
                foreach (var obj in ConvertedTableData_temp.data)
                {
                    if (obj.name.ToLowerInvariant().Contains(searchterm)) 
                    {  
                        TableDataObjectList.Add(obj);
                    }
                }
            }
        }

        public ICommand GoToOptionsCommand => new Command(GoToOptions);
        async void GoToOptions() 
        {
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }


    }
}
