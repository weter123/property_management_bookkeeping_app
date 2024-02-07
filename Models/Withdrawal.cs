using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordKeepingApp.Models
{
    [Table("Withdrawal")]
    public class Withdrawal
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(500)]
        public string Comment { get; set; }

        [MaxLength(250)]
        public int Amount { get; set; }

        [MaxLength(250)]
        public String Date { get; set; }

        [MaxLength(250)]
        public DateTime InsertDate { get; set; }
    }
}
