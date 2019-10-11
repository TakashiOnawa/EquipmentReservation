using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EquipmentReservation.Infrastructure.Database.Tables
{
    [Table("reservations")]
    public class RESERVATIONS
    {
        [Key]
        public string id { get; set; }
        public string accounts_id { get; set; }
        public string equipments_id { get; set; }
        public DateTime start_date_time { get; set; }
        public DateTime end_date_time { get; set; }
        public string purpose_of_use { get; set; }

        public RESERVATIONS_STATUS reservations_status { get; set; }
    }
}
