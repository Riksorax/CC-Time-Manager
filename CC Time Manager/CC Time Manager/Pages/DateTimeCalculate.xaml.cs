using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC_Time_Manager.Models;
using CC_Time_Manager.Pages;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CC_Time_Manager.Pages
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class DateTimeCalculate : ContentPage
    {
        public string ItemId
        {
            set
            {
                LoadDateTimeHours(value);
            }
        }

        public DateTimeCalculate()
        {
            InitializeComponent();

            BindingContext = new DateTimeHours();
        }

        public void TimeCalculate()
        {

            //Hier werden die gesamten Stunden mit der Pause berechnet und ausgegeben
            TimeSpan totalhours = endTimePicker.Time - startTimePicker.Time;
            TimeSpan hoursWBreak = totalhours - breakTime.Time;
            hoursTotal_Label.BindingContext = hoursWBreak;

            //Hier werde die tatsächlichen Stunden mit den eigentlichen stunden verrechnet
            double workHours = 7.7;
            TimeSpan hours = TimeSpan.FromHours(workHours);
            TimeSpan overTiToday = hoursWBreak - hours;


            if (overTiToday < hours)
            {
                overTimeToday_Label.BindingContext = overTiToday;
            }
            else if (overTiToday > hours)
            {
                double overTimeTyZero = 0.0;
                TimeSpan zero = TimeSpan.FromMinutes(overTimeTyZero);
                overTimeToday_Label.BindingContext = zero;
            }


            //Hier sind die gesamten Überstunden standtmäißg  auf  null
            int overTimeZero = 0;
            TimeSpan overTimeTotal = TimeSpan.FromHours(overTimeZero);
            overTimeTotal_Label.BindingContext = overTimeTotal;

            //Hie werden die Kompletten überstunden ausgerechnet

            if (hoursWBreak < hours)
            {

                TimeSpan overTimeTotal1 = overTimeTotal + overTiToday;
                overTimeTotal_Label.BindingContext = overTimeTotal1;

            }
            else if (hoursWBreak > hours)
            {

                TimeSpan overTimeTotal1 = overTimeTotal - overTiToday;
                overTimeTotal_Label.BindingContext = overTimeTotal1;
            }

        }



        //hier kann man seine Stunden manuell wieder abziehen
        //TODO BERCHNUNG NOCH MAL DRÜBER SCHAUEN UND PROB FIXEN 
        public void OverTimeMinus()
        {

        }
        //Hier kann ich die Überstunden mauell hinzufüegn
        public void OverTimePlus()
        {
            TimeSpan overTimeTotal = TimeSpan.Parse(overTimeTotal_Label.Text);

            TimeSpan overTimeNew = overTimeTotal + overHoursPTimePicker.Time;

            overTimeTotal_Label.BindingContext = overTimeNew;
        }

        //  Der Date Picker muss noch eingerichtet werden so das die ausrechnung noch gelöscht wird
        private void DateToday_DateSelected(object sender, DateChangedEventArgs e)
        {
            
        }

        // Der Button lässt die Zeit ausrechnen
        private void HoursButton_Clicked(object sender, EventArgs e)
        {

            TimeCalculate();

        }

        async void LoadDateTimeHours(string itemId)
        {
            try
            {
                int id = Convert.ToInt32(itemId);
                // Retrieve the note and set it as the BindingContext of the page.
                DateTimeHours dateTimeHour = await App.DataDateTimeHours.GetDateTimeHoursAsync(id);
                BindingContext = dateTimeHour;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load note.");
            }
        }

        // Der Button soll die Zeiten und Daten abspeichern
        async void SaveTime_Clicked(object sender, EventArgs e)
        {
            var dateTimeHour = (DateTimeHours)BindingContext;
            if (!string.IsNullOrWhiteSpace(dateTimeHour.Date))
            {
                await App.DataDateTimeHours.SaveDateTimeAsync(dateTimeHour);
            }
            if (!string.IsNullOrWhiteSpace(hoursTotal_Label.Text))
            {
                await App.DataDateTimeHours.SaveDateTimeAsync(dateTimeHour);
            }
            if (!string.IsNullOrWhiteSpace(dateTimeHour.OverTime_Today))
            {
                await App.DataDateTimeHours.SaveDateTimeAsync(dateTimeHour);
            }
            if (!string.IsNullOrWhiteSpace(dateTimeHour.OverTime_Total))
            {
                await App.DataDateTimeHours.SaveDateTimeAsync(dateTimeHour);
            }
            else
            {
                await DisplayAlert("Achtung", "Es kommt eine Exeption","OK");
            }
            await Shell.Current.GoToAsync("..");
        }

 /*       async void OnDeleteButtonClicked(object sender,EventArgs e)
        {
            var dateTimeHour = (DateTimeHours)BindingContext;
            await App.DataDateTimeHours.DeleteDateTimeHoursAsync(dateTimeHour);

            // Navigate backwards
            await Shell.Current.GoToAsync("");
        }

*/

        // Der Button soll dafür da sein das man seine Manuellen überstunden bestätigen kann
        private void OverTimeChange_Clicked(object sender, EventArgs e)
        {

            OverTimePlus();

        }

        
    }
}