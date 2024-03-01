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
        public string WithdrawalComment { get; set; }

        [MaxLength(250)]
        public int WithdrawalAmount { get; set; }

        [MaxLength(250)]
        public String WithdrawalDate { get; set; }

        [MaxLength(250)]
        public DateTime InsertDate { get; set; }
    }
}
