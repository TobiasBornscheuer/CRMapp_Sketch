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
        private async void Search(string query)
        {
            if (!string.IsNullOrEmpty(query)) // only clear list and execute search if searchterm is valid
            {
                var searchterm = query.ToLowerInvariant(); // make query string case insensitve

                // clear the existing ViewModel-Collection if there are items in it
                if (TableDataObjectList != null)
                    TableDataObjectList.Clear();

                // loop over each object in the data source and add it to the ViewModel-Collection if it meets the search criteria
                foreach (var obj in SourceData_temp.data)
                {
                    if (obj.name.ToLowerInvariant().Contains(searchterm)) // object attribute is also made case insensitive
                    {  
                        TableDataObjectList.Add(obj);
                    }
                }
                // if the ViewModel-Collection is still empty after the search, inform the user that there were no matches
                // normally I'd do TableDataObjectList == null, but the ObservableCollection is never null for some reason
                // This workaround let's the DisplayAlert be fired, but is probaly not an optimal solution
                if (TableDataObjectList.ToList().Count == 0)
                {
                    await App.Current.MainPage.DisplayAlert("Information", "There were no matches found, for the search term you provided", "OK");
                }
            }
            // if there is not text in the searchbar, the Command is never triggered. This is default behavior
            // Because of that, no DisplayAlert in case of missing search term will be implemented.
            // There are workarounds, which may be specific to each platform
        }

        public ICommand GoToOptionsCommand => new Command(GoToOptions);
        async void GoToOptions() 
        {
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }


    }
}
