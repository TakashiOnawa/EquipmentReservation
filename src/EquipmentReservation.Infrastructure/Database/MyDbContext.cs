using Dapper;
using EquipmentReservation.Infrastructure.Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentReservation.Infrastructure.Database
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql("Host=localhost;Username=EquipmentReservation;Password=EquipmentReservation!234;Database=EquipmentReservation");
        }

        public DbSet<ACCOUNTS> Accounts { get; private set; }
        public DbSet<EQUIPMENTS> Equipments { get; private set; }
        public DbSet<RESERVATIONS> Reservations { get; private set; }
        public DbSet<RESERVATIONS_STATUS> ReservationsStatus { get; private set; }

        public T QueryObject<T>(string query, object parameter)
        {
            return Query<T>(query, parameter).FirstOrDefault();
        }

        public IEnumerable<T> QueryObjects<T>(string query, object parameter = null)
        {
            return Query<T>(query, parameter).ToList();
        }

        private IEnumerable<T> Query<T>(string query, object parameter = null)
        {
            return Database.GetDbConnection().Query<T>(query, parameter, transaction: Database.CurrentTransaction?.GetDbTransaction());
        }
    }

    public class TestDBInitializer
    {
        public void Initialize(MyDbContext dbContext)
        {
            if (dbContext.Accounts.Count() > 0)
                return;

            var accounts = new List<ACCOUNTS>();
            accounts.Add(new ACCOUNTS() { id = new EquipmentReservation.Domain.Accounts.AccountId().Value, account_name = "アカウント1" });
            accounts.Add(new ACCOUNTS() { id = new EquipmentReservation.Domain.Accounts.AccountId().Value, account_name = "アカウント2" });
            accounts.Add(new ACCOUNTS() { id = new EquipmentReservation.Domain.Accounts.AccountId().Value, account_name = "アカウント3" });
            dbContext.AddRange(accounts);

            var equipments = new List<EQUIPMENTS>();
            equipments.Add(new EQUIPMENTS() { id = new EquipmentReservation.Domain.Equipments.EquipmentId().Value, equipment_type = (int)EquipmentReservation.Domain.Equipments.EquipmentTypes.USB, equipment_name = "USB1" });
            equipments.Add(new EQUIPMENTS() { id = new EquipmentReservation.Domain.Equipments.EquipmentId().Value, equipment_type = (int)EquipmentReservation.Domain.Equipments.EquipmentTypes.PocketWifi, equipment_name = "ポケットWifi1" });
            equipments.Add(new EQUIPMENTS() { id = new EquipmentReservation.Domain.Equipments.EquipmentId().Value, equipment_type = (int)EquipmentReservation.Domain.Equipments.EquipmentTypes.CellPhone, equipment_name = "携帯電話1" });
            dbContext.AddRange(equipments);

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
                    dbContext.Add(reservation);

                    var reservationsStatus = new RESERVATIONS_STATUS()
                    {
                        reservations_id = reservation.id,
                        status = 0
                    };
                    dbContext.Add(reservationsStatus);

                    additionalDay++;
                }
            }

            dbContext.SaveChanges();
        }
    }
}
