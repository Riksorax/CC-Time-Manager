using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CC_Time_Manager.Models;
using CC_Time_Manager.Pages;
using SQLite;
using Xamarin.Forms;

namespace CC_Time_Manager.Data
{  
    public class DateTimeRepository
    {
        private SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        /*private DateTimeRepository(SQLiteAsyncConnection SQLiteAsyncConnection)
        {
            this.conn = SQLiteAsyncConnection;
        }
        */
        public DateTimeRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<DateTimeHours>().Wait();
        }
        

        public async Task AddNewDateTimeHours(string dateTimeHours) //, string hours_Today, string overTime_Today, string overTime_Total
        {
            int result = 0;
            try
            {
                if (string.IsNullOrEmpty(dateTimeHours))
                    throw new Exception("Valid date required");

                await conn.InsertAsync(new DateTimeHours { Date = dateTimeHours });
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, dateTimeHours);

                /*
                if (string.IsNullOrEmpty(dateTimeHours))
                    throw new Exception("Valid Hours Today required");

                await conn.InsertAsync(new DateTimeHours { Hours_Today = dateTimeHours });
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, dateTimeHours);

                if (string.IsNullOrEmpty(dateTimeHours))
                    throw new Exception("Valid OverTime Today required");

                await conn.InsertAsync(new DateTimeHours { OverTime_Today = dateTimeHours });
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, dateTimeHours);

                if (string.IsNullOrEmpty(dateTimeHours))
                    throw new Exception("Valid OverTime Total required");

                await conn.InsertAsync(new DateTimeHours { OverTime_Total = dateTimeHours });
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, dateTimeHours);
                */
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", dateTimeHours, ex.Message); // hours_Today, overTime_Today, overTime_Total,
            }
        }

        public async Task<List<DateTimeHours>> GetDateTimeHoursAsync()
        {
            try
            {
                //Get all notes.
                return await conn.Table<DateTimeHours>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<DateTimeHours>();
        }

        
        

            /*       public Task<int> DeleteDateTimeHoursAsync(DateTimeHours dateTimeHours)
                   {
                       // Delete a note.
                       return dataDateTimeHours.DeleteAsync(dateTimeHours);
                   }
                */
        
    }
}