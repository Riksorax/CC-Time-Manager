using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Linq;
using System.Text;
using CC_Time_Manager.Data;
using CC_Time_Manager.Pages;
using System.IO;
using Xamarin.Essentials;

namespace CC_Time_Manager
{
    public partial class App : Application
    {
        string dbPath => FileAccessHelper.GetLocalFilePath("dateTime.db3");
        public static DateTimeRepository DataDateTimeHours { get; private set; }

        public App()
        {
            InitializeComponent();

            DataDateTimeHours = new DateTimeRepository(dbPath);

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
