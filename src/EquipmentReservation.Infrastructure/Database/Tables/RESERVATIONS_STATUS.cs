using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EquipmentReservation.Infrastructure.Database.Tables
{
    [Table("reservations_status")]
    public class RESERVATIONS_STATUS
    {
        [Key]
        public string reservations_id { get; set; }
        public int status { get; set; }

        [ForeignKey("reservations_id")]
        public virtual RESERVATIONS reservations { get; set; }
    }
}
