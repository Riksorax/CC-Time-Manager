using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CC_Time_Manager.Models
{
    class DateTimeHours
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(250), Unique]
        public string Date { get; set; }

        [MaxLength(250), Unique]
        public string Hours_Today { get; set; }

        [MaxLength(250), Unique]
        public string OverTime_Today { get; set; }

        [MaxLength(250), Unique]
        public string OverTime_Total { get; set; }

    }
}
