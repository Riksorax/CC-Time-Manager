using SQLite;

namespace CC_Time_Manager.Models
{

    public class DateTimeHours
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [PrimaryKey, Unique]
        public string Date { get; set; }
        [Unique]
        public string Hours_Today { get; set; }
        [Unique]
        public string OverTime_Today { get; set; }
        [Unique]
        public string OverTime_Total { get; set; }

    }
}
