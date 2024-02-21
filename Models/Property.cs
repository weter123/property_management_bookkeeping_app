using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace RecordKeepingApp.Models
{
    [Table("Property")]
    public class Property
    {
        [PrimaryKey]
        public int Page { get; set; }

        [MaxLength(250)]
        public string DoorNumber { get; set; }

        [MaxLength(500)]
        public string Type { get; set; }

        [MaxLength(500)]
        public string Renter { get; set; }

        [MaxLength(500)]
        public string PropertySequence { get; set; }

        public int RentalAmount { get; set; }

        [MaxLength(500)]
        public string PhoneNumber { get; set; }

        [MaxLength(250)]
        public DateTime InsertDate { get; set; }
    }
}
