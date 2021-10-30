using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;
using CC_Time_Manager.Data;
using CC_Time_Manager.Pages;
using System.IO;

namespace CC_Time_Manager
{
    public partial class App : Application
    {
        static DateTimeRepository dataDateTimeHours;

        

        public static DateTimeRepository DataDateTimeHours
        {
            get
            {
                if(dataDateTimeHours == null)
                {
                    dataDateTimeHours = new DateTimeRepository(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CC_Time_Manager.db3"));
                }
                return dataDateTimeHours;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new CC_Time_Manager.MainPage();

        }


        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
