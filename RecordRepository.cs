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
            conn.CreateTableAsync<Property>();
        }

        public RecordRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async void AddNewPaymentRecord(string name, string address, int amount, String date)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                Init();
                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name) )
                    throw new Exception("Valid name required");
                if (string.IsNullOrEmpty(address))
                    throw new Exception("Valid address required");

                DateTime thisDay = DateTime.Now;
                // TODO: Insert the new person into the database
                result = await conn.InsertAsync(new Payment { PayerName = name, PaymentAmount = amount, PayerAddress = address, PaymentDate = date , InsertDate = thisDay });

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

        public async Task<List<Payment>> GetAllRecords()
        {
            try
            {
                Init();
                return await conn.QueryAsync<Payment>("" +
                    "SELECT PayerName, PayerAddress, PaymentAmount, PaymentDate, InsertDate FROM Payment ");      
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Payment>();
        }

        public async Task<List<Property>> GetAllProperties()
        {
            // TODO: Init then retrieve a list of Person objects from the database into a list
            try
            {
                Init();
                return await conn.QueryAsync<Property>("" +
                    "SELECT * FROM Property ");



            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Property>();
        }

        public async void AddNewProperty(int page, string doorNo, string type, string renter, string sequence, int amount, string phoneNo)
        {
            int result = 0;
            try
            {
                // TODO: Call Init()
                Init();
                // basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(renter))
                    throw new Exception("Valid name required");

                DateTime thisDay = DateTime.Now;
                // TODO: Insert the new property into the database
                result = await conn.InsertAsync(new Property { Page = page, DoorNumber = doorNo, PropertyType = type, Renter = renter, PropertySequence = sequence, RentalAmount = amount, PhoneNumber = phoneNo, InsertDate = thisDay });

                StatusMessage = string.Format("{0} property(s) added (page: {1})", result, page);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", renter, ex.Message);
            }

        }

        public async Task<List<Property>> GetAllPropertyIds()
        {
            Init();
            try
            {
                return await conn.QueryAsync<Property>("" +
                    "SELECT page FROM Property ");

            } catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to get property Ids. Error: {0}", ex.Message);
            }
            return new List<Property> {};
        }
    }
}
