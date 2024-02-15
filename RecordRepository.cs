using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
namespace RecordKeepingApp.Models
{
    public class RecordRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }

        // TODO: Add variable for the SQLite connection
        private SQLiteAsyncConnection conn;
        private void Init()
        {
            // TODO: Add code to initialize the repository
            if (conn != null)
                return;
            conn = new SQLiteAsyncConnection(_dbPath, Constants.Flags);
            conn.CreateTableAsync<Payment>();
            conn.CreateTableAsync<Withdrawal>();
        }

        public RecordRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async void AddNewPaymentRecord(string name, string address, int amount, DateTime s, DateTime e)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                Init();
                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name) )
                    throw new Exception("Valid name required");

                DateTime thisDay = DateTime.Now;
                // TODO: Insert the new person into the database
                result = await conn.InsertAsync(new Payment { Name = name, Amount = amount, Address = address, Date = s.ToString("d") + " - " + e.ToString("d"), InsertDate = thisDay });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async void AddNewWithdrawalRecord(string name, int amount, DateTime s)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                Init();
                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                DateTime thisDay = DateTime.Now;
                // TODO: Insert the new person into the database
                result = await conn.InsertAsync(new Withdrawal { Comment = name, Amount = amount, Date = s.ToString("d"), InsertDate = thisDay });

                StatusMessage = string.Format("{0} record(s) added (Comment: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async Task<List<Payment>> GetAllRecords()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                Init();
                return await conn.QueryAsync<Payment>("" +
                    "SELECT Name, Address, Amount, Date, InsertDate FROM Payment " +
                    "Union " +
                    "SELECT Comment, null, Amount, Date, InsertDate FROM Withdrawal");
                

               
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Payment>();
        }
    }
}
