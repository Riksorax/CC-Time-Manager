using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CC_Time_Manager.Models;
using CC_Time_Manager.Pages;
using SQLite;
using Xamarin.Forms;

namespace CC_Time_Manager
{


    public partial class MainPage : TabbedPage
    {
        

        public MainPage()
        {
            InitializeComponent();

            
            this.Children.Add(new DateTimeCalculate());
            this.Children.Add(new DateTimeChart());
            this.Children.Add(new PieceRatePage());          
            
            
        }

    }
}
