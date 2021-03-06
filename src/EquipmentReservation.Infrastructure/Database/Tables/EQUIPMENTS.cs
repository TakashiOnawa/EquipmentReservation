﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EquipmentReservation.Infrastructure.Database.Tables
{
    [Table("equipments")]
    public class EQUIPMENTS
    {
        [Key]
        public string id { get; set; }
        public int equipment_type { get; set; }
        public string equipment_name { get; set; }
    }
}
