using CC_Time_Manager.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CC_Time_Manager.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateTimeChart : ContentPage
    {
        public DateTimeChart()
        {
            InitializeComponent();

            BindingContext = new DateTimeHours();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            dateTimeHoursList.ItemsSource = await App.DataDateTimeHours.GetDateTimeHoursAsync();
            

        }
        public async void LoadList_Clicked(object sender, EventArgs e)
        {
            
            // Navigate to the NoteEntryPage.
            
            List<DateTimeHours> dateTimeHours = await App.DataDateTimeHours.GetDateTimeHoursAsync();
            dateTimeHoursList.ItemsSource = dateTimeHours;
            dateTimeHoursList.ItemsSource = dateTimeHours;
            dateTimeHoursList.ItemsSource = dateTimeHours;
            dateTimeHoursList.ItemsSource = dateTimeHours;
            

        }
        
       /* async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the ID as a query parameter.
                DateTimeHours dateTimeHours = (DateTimeHours)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(DateTimeCalculate)}?{nameof(DateTimeCalculate.ItemId)}={dateTimeHours.ID.ToString()}");
            }
        }*/

    }
}