using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CC_Time_Manager
{
    

    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();

            
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
            overTimeToday_Label.BindingContext = overTiToday;
            
            /*
            //Hier werden die Heutigen Überstunden mit den Insgesamten Überstunden zusammen addiert
            if(dateToday == DateTime.Now = true) 
            {
                TimeSpan overTimeTotal = overTiToday + overTiToday;
                overTimeTotal_Label.BindingContext = overTimeTotal;
            }
            else
            {
                overTimeToday_Label.BindingContext = overTiToday;
            }
            */
        }

        public void OverTimeMinus()
        {

        }

        public void OverTimePlus()
        {

        }

        private void HoursButton_Clicked(object sender, EventArgs e)
        {
            TimeCalculate();

        }

        private void OverTimeChange_Clicked(object sender, EventArgs e)
        {

        }
    }
}
