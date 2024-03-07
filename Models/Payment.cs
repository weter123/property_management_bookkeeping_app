using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using TableAttribute = SQLite.TableAttribute;

namespace RecordKeepingApp.Models
{
    [Table("Payment")]
    public class Payment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey("Property")]
        public int PropertyPage { get; set; }

        [MaxLength(250)]
        public int PaymentAmount { get; set; }

        [MaxLength(250)]
        public string PaymentDate { get; set; }

        [MaxLength(250)]
        public DateTime InsertDate { get; set; }
    }
}
