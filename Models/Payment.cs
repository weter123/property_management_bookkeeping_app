using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace RecordKeepingApp.Models
{
    [Table("Payment")]
    public class Payment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(500)]
        public string PayerName { get; set; }

        [MaxLength(250)]
        public string PayerAddress { get; set; }

        [MaxLength(250)]
        public int PaymentAmount { get; set; }

        [MaxLength(250)]
        public String PaymentDate { get; set; }

        [MaxLength(250)]
        public DateTime InsertDate { get; set; }
    }
}
