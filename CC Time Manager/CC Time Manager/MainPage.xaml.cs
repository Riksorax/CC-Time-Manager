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


    
        //Ab hier kann man seine Stunden manuell hinzufügen und auch wieder abziehen
        //TODO BERCHNUNG NOCH MAL DRÜBER SCHAUEN UND PROB FIXEN 
        public void OverTimeMinus()
        {
            TimeSpan overTimeTotal = TimeSpan.Parse(overTimeTotal_Label.Text);
            TimeSpan overTimeMinus = TimeSpan.Parse(overTimeMTimePicker.Text);
            TimeSpan newOverTimeM = overTimeMinus - overTimeTotal;
            overTimeTotal_Label.BindingContext = newOverTimeM;
        }

        public void OverTimePlus()
        {
            double overTimeTotal = TimeSpan.Parse(overTimeTotal_Label.Text).TotalHours;
            double overTimePlus = TimeSpan.Parse(overHoursPTimePicker.Text).TotalHours;
            double newOverTimeP = overTimePlus + overTimeTotal;
            
            overTimeTotal_Label.BindingContext = newOverTimeP;
        }

        // Der Button lässt die Zeit ausrechnen
        private void HoursButton_Clicked(object sender, EventArgs e)
        {
            TimeCalculate();

        }

        // Der Button soll die Zeiten und Daten abspeichern
        private void SaveTime_Clicked(object sender, EventArgs e)
        {
            //TODO Save Datei hinzufügen
        }

        // Der Button soll dafür da sein das man seine Manuellen überstunden bestätigen kann
        private void OverTimeChange_Clicked(object sender, EventArgs e)
        {
            
            OverTimePlus();
            
        }
    }
}
