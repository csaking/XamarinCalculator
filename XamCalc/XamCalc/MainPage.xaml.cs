using System;
using Xamarin.Forms;
using Entry = XamCalc.Models.Entry;

namespace XamCalc
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetEntriesAsync();
        }

        async void OnEntryAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calculator
            {
                BindingContext = new Entry()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new Calculator
                {
                    BindingContext = e.SelectedItem as Entry
                });
            }
        }
    }
}
