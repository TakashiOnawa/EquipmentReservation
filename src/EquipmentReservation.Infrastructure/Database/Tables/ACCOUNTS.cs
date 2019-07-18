using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EquipmentReservation.Infrastructure.Database.Tables
{
    [Table("accounts")]
    public class ACCOUNTS
    {
        [Key]
        public string id { get; set; }
        public string account_name { get; set; }
    }
}
