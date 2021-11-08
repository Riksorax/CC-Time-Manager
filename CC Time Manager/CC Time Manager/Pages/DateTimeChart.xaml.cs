using CC_Time_Manager.Data;
using CC_Time_Manager.Models;
using DevExpress.Data.XtraReports.Native;
using MvvmHelpers.Commands;
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
        public ObservableRangeCollection<DateTimeHours> DateTimeHours { get; set; }
        public AsyncCommand RefreshCommand { get; }
        public AsyncCommand AddCommand { get; }
        public AsyncCommand<DateTimeRepository> RemoveCommand { get; }
        public AsyncCommand<DateTimeRepository> SelectedCommand { get; }



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
            List<DateTimeHours> dateTimeHours = await App.DataDateTimeHours.GetDateTimeHoursAsync();
            dateTimeHoursList.ItemsSource = await App.DataDateTimeHours.GetDateTimeHoursAsync();
            dateTimeHoursList.ItemsSource = dateTimeHours;

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

        

        async Task Add()
        {
            //await App.Current.DateTimeCalcculate.DisplayPromptAsync("Datum", "");
            //await App.Current.MainPage.DisplayPromptAsync("Heutige Std.", "");
            //await App.Current.MainPage.DisplayPromptAsync("Heutige Übersd.", "");
            //await App.Current.MainPage.DisplayPromptAsync("Komplette Überstd.", "");
            //dateTimeHoursList.ItemsSource = ;
            await Refresh();
        }

        async Task Remove(DateTimeHours dateTimeHours)
        {
            //await DateTimeRepository.DeleteDateTimeHoursAsync(dateTimeHours.Id);
            await Refresh();
        }

        async Task Refresh()
        {
            IsBusy = true;

            await Task.Delay(2000);

            DateTimeHours.Clear();

            List<DateTimeHours> dateTimeHours = await App.DataDateTimeHours.GetDateTimeHoursAsync();
            dateTimeHoursList.ItemsSource = dateTimeHours;
            //var dateTimeHour = await DateTimeRepository.GetDateTimeHoursAsync();

            DateTimeHours.AddRange(dateTimeHours);

            IsBusy = false;
        }
    }
}