using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;
using System.Xml.Linq;

namespace RecordKeepingApp
{
    public class InputValidations
    {
        public struct Validations
        {
            public bool result;
            public string message;

        }
        public static Validations ValidateInsertNewPaymentInput(int id, int amount, DateTime startDate, DateTime endDate)
        {
            Validations validation;
            DateTime minDate = new DateTime(2023, 12, 31);
            if (id == 0)
            {
                validation.result = false;
                validation.message = "Please select a property";
                return validation;
            }
            if (amount <= 0)
            {
                validation.result = false;
                validation.message = "Please enter a valid amount";
                return validation;
            }
            if (startDate == minDate)
            {
                validation.result = false;
                validation.message = "Please select a start date";
                return validation;
            }
            if (endDate == minDate)
            {
                validation.result = false;
                validation.message = "Please select an end date";
                return validation;
            }

            validation.result = true;
            validation.message = "";
            return validation;
        }

        public static Validations ValidateInsertNewPropertyInput(int pageNumber, int amount, string doorNo,string type, string name, string sequence, string phone)
        {
            Validations validation;
            if (pageNumber <= 0)
            {
                validation.result = false;
                validation.message = "Please enter a valid property page";
                return validation;
            }
            
            if (string.IsNullOrEmpty(doorNo))
            {
                validation.result = false;
                validation.message = "Please insert a door number";
                return validation;
            }
            if (string.IsNullOrEmpty(type))
            {
                validation.result = false;
                validation.message = "Please insert a type";
                return validation;
            }
            if (string.IsNullOrEmpty(name))
            {
                validation.result = false;
                validation.message = "Please insert a name";
                return validation;
            }
            if (string.IsNullOrEmpty(sequence))
            {
                validation.result = false;
                validation.message = "Please insert a sequence";
                return validation;
            }
            if (amount <= 0)
            {
                validation.result = false;
                validation.message = "Please enter a valid amount";
                return validation;
            }
            if (string.IsNullOrEmpty(phone))
            {
                validation.result = false;
                validation.message = "Please insert a phone number";
                return validation;
            }


            validation.result = true;
            validation.message = "";
            return validation;
        }
    }
}
