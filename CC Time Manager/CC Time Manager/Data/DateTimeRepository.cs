using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        readonly SQLiteAsyncConnection dataDateTimeHours;

        public DateTimeRepository(string dbPath)
        {
            dataDateTimeHours = new SQLiteAsyncConnection(dbPath);
            dataDateTimeHours.CreateTableAsync<DateTimeHours>().Wait();
        }

        public Task<List<DateTimeHours>> GetDateTimeHoursAsync()
        {
            //Get all notes.
            return dataDateTimeHours.Table<DateTimeHours>().ToListAsync();
        }

        public Task<DateTimeHours> GetDateTimeHoursAsync(int id)
        {
            // Get a specific note.
            return dataDateTimeHours.Table<DateTimeHours>()
                                .Where(i => i.ID == id)
                                .FirstOrDefaultAsync();
        }

        public Task<int> SaveDateTimeAsync(DateTimeHours dateTimeHours)
        {
            if (dateTimeHours.ID != 0)
            {
                // Update an existing note.
                return dataDateTimeHours.UpdateAsync(dateTimeHours);
            }
            else
            {
                // Save a new note.
                return dataDateTimeHours.InsertAsync(dateTimeHours);
            }
            if (string.IsNullOrEmpty(dateTimeHours.Date))
            {
                // Update an existing note.
                return dataDateTimeHours.UpdateAsync(dateTimeHours);
            }
            else
            {
                // Save a new note.
                return dataDateTimeHours.InsertAsync(dateTimeHours);
            }
            if (string.IsNullOrEmpty(dateTimeHours.Hours_Today))
            {
                // Update an existing note.
                return dataDateTimeHours.UpdateAsync(dateTimeHours);
            }
            else
            {
                // Save a new note.
                return dataDateTimeHours.InsertAsync(dateTimeHours);
            }
            if (string.IsNullOrEmpty(dateTimeHours.OverTime_Today))
            {
                // Update an existing note.
                return dataDateTimeHours.UpdateAsync(dateTimeHours);
            }
            else
            {
                // Save a new note.
                return dataDateTimeHours.InsertAsync(dateTimeHours);
            }
            if (string.IsNullOrEmpty(dateTimeHours.OverTime_Total))
            {
                // Update an existing note.
                return dataDateTimeHours.UpdateAsync(dateTimeHours);
            }
            else
            {
                // Save a new note.
                return dataDateTimeHours.InsertAsync(dateTimeHours);
            }

            /*       public Task<int> DeleteDateTimeHoursAsync(DateTimeHours dateTimeHours)
                   {
                       // Delete a note.
                       return dataDateTimeHours.DeleteAsync(dateTimeHours);
                   }
                */
        }
    }
}