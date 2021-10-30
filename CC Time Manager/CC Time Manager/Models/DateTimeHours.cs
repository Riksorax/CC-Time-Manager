using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CC_Time_Manager.Models
{
    public class DateTimeHours
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Date { get; set; }        
        public string Hours_Today { get; set; }        
        public string OverTime_Today { get; set; }        
        public string OverTime_Total { get; set; }

    }
}
