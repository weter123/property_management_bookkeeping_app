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
            conn.CreateTableAsync<Payment>();
        }

        public RecordRepository(string dbPath)
        {
            _dbPath = dbPath;
        }

        public async void AddNewPaymentRecord(int page, int amount, String date)
        {

            try
            {
                // TODO: Call Init()
                Init();
               
                DateTime thisDay = DateTime.Now;
                // TODO: Insert the new person into the database
                await conn.InsertAsync(new Payment { PropertyPage = page , PaymentAmount = amount, PaymentDate = date , InsertDate = thisDay });

                StatusMessage = string.Format("a record has been added (Page: {0})", page);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", page, ex.Message);
            }

        }

        public async Task<List<PaymentProperty>> GetAllPayments()
        {
            try
            {
                Init();
                return await conn.QueryAsync<PaymentProperty>("" +
                    "SELECT pr.Renter AS NameColumn, pr.DoorNumber AS AddressColumn , pa.PaymentAmount AS AmountColumn, " +
                    "pa.PaymentDate AS PaymentDateColumn, pa.InsertDate AS InsertDateColumn  " +
                    "FROM Payment pa " +
                    "INNER JOIN Property pr " +
                    "ON pa.PropertyPage = pr.Page");
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<PaymentProperty>();
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
/*
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
*/
        public async Task<Property> GetOneProperty(int pageId)
        {
            Init();
            try
            {
                return await conn.FindWithQueryAsync<Property>("" +
                    "SELECT * FROM Property " +
                    "WHERE Page =" + pageId);

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to find {0}. Error: {1}", pageId, ex.Message);
            }
            return new Property { };
        }
    }
}
