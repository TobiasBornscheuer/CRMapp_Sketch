using DLKapp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;


namespace DLKapp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Removes the BackButton from the page
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}




/*
 ==> MainPage before MVVM was implemented 

public partial class MainPage : ContentPage
{
    ObservableCollection<TableDataObject> table_collection = new ObservableCollection<TableDataObject>()
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
    public MainPage()
    {
        InitializeComponent();
        my_list.ItemsSource = table_collection;
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        my_list.ItemsSource = table_collection.Where(s => s.name.StartsWith(e.NewTextValue));
    }

    private async void settings_button_Pressed(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingsPage()); //check if modal is better option
    }
}
*/