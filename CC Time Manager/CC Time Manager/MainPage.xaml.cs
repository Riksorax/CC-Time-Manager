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
            /*
            if (hoursWBreak < hours)
            {
               
                TimeSpan overTimeTotal = overTimeTotal + overTiToday;
                overTimeTotal_Label.BindingContext = overTimeTotal;
                
            }
            else if (hoursWBreak > hours)
            {
                
                TimeSpan overTimeTotal = overTimeTotal - overTiToday;
                overTimeTotal_Label.BindingContext = overTimeTotal;
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
