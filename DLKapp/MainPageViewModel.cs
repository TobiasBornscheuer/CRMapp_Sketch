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
                if (TableDataObjectList == null)
                {
                    await App.Current.MainPage.DisplayAlert("Information", "There were no matches found, for the search term you provided", "OK");
                }
            }
            else // if the user did not provide a search term, inform him of that
            {
                await App.Current.MainPage.DisplayAlert("Information", "You did not provide a search term", "OK");
            }
        }

        public ICommand GoToOptionsCommand => new Command(GoToOptions);
        async void GoToOptions() 
        {
            await App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
        }


    }
}
