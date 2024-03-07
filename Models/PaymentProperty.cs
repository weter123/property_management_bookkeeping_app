using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordKeepingApp.Models
{
    public class PaymentProperty
    {
        public string NameColumn { get; set; }

        public string AddressColumn { get; set; }

        public int AmountColumn { get; set; }

        public string PaymentDateColumn { get; set; }

        public DateTime InsertDateColumn { get; set; }


    }
}
