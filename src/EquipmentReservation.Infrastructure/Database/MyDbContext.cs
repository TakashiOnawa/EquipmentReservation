using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using EquipmentReservation.Infrastructure.Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace EquipmentReservation.Infrastructure.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<ACCOUNTS> Accounts { get; set; }
        public DbSet<EQUIPMENTS> Equipments { get; set; }
        public DbSet<RESERVATIONS> Reservations { get; set; }
    }

    public class SampleAppInitializer
    {
        public void Initialize(MyDbContext dbContext)
        {
            if (dbContext.Accounts.Count() > 0)
                return;

            var accounts = new List<ACCOUNTS>();
            accounts.Add(new ACCOUNTS() { id = new EquipmentReservation.Domain.Accounts.AccountId().Value, account_name = "アカウント1" });
            accounts.Add(new ACCOUNTS() { id = new EquipmentReservation.Domain.Accounts.AccountId().Value, account_name = "アカウント2" });
            accounts.Add(new ACCOUNTS() { id = new EquipmentReservation.Domain.Accounts.AccountId().Value, account_name = "アカウント3" });
            dbContext.Accounts.AddRange(accounts);

            var equipments = new List<EQUIPMENTS>();
            equipments.Add(new EQUIPMENTS() { id = new EquipmentReservation.Domain.Equipments.EquipmentId().Value, equipment_type = (int)EquipmentReservation.Domain.Equipments.EquipmentTypes.USB, equipment_name = "USB1" });
            equipments.Add(new EQUIPMENTS() { id = new EquipmentReservation.Domain.Equipments.EquipmentId().Value, equipment_type = (int)EquipmentReservation.Domain.Equipments.EquipmentTypes.PocketWifi, equipment_name = "ポケットWifi1" });
            equipments.Add(new EQUIPMENTS() { id = new EquipmentReservation.Domain.Equipments.EquipmentId().Value, equipment_type = (int)EquipmentReservation.Domain.Equipments.EquipmentTypes.CellPhone, equipment_name = "携帯電話1" });
            dbContext.Equipments.AddRange(equipments);

            var reservations = new List<RESERVATIONS>();
            var additionalDay = 1;
            var startDateTime = DateTime.Now;
            foreach (var account in accounts)
            {
                foreach (var equipment in equipments)
                {
                    var reservation = new RESERVATIONS()
                    {
                        id = new EquipmentReservation.Domain.Reservations.ReservationId().Value,
                        accounts_id = account.id,
                        equipments_id = equipment.id,
                        start_date_time = startDateTime.AddDays(additionalDay),
                        end_date_time = startDateTime.AddDays(additionalDay + 1),
                        purpose_of_use = "テスト"
                    };
                    reservations.Add(reservation);

                    additionalDay++;
                }
            }
            dbContext.AddRange(reservations);

            dbContext.SaveChanges();
        }
    }
}
