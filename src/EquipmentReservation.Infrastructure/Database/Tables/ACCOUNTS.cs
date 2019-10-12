using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
