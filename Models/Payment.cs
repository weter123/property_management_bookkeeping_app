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
        public string Name { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(250)]
        public int Amount { get; set; }

        [MaxLength(250)]
        public String Date { get; set; }

        [MaxLength(250)]
        public DateTime InsertDate { get; set; }
    }
}
