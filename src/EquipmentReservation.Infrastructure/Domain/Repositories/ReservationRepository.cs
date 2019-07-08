using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;

namespace EquipmentReservation.Infrastructure.Domain.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        public static readonly List<Reservation> _data = new List<Reservation>();

        static ReservationRepository()
        {
            var additionalDay = 1;
            var startDateTime = DateTime.Now;
            foreach (var account in AccountRepository._data)
            {
                foreach (var equipment in EquipmentRepository._data)
                {
                    var reservation = new Reservation(
                        new ReservationId(),
                        account.Id,
                        equipment.Id,
                        new ReservationDateTime(startDateTime.AddDays(additionalDay), startDateTime.AddDays(additionalDay + 1)),
                        "テスト");
                    _data.Add(reservation);

                    additionalDay++;
                }
            }
        }

        public Reservation Find(ReservationId reservationId)
        {
            return _data.Find(_ => _.Id == reservationId);
        }

        public IEnumerable<Reservation> FindByEquipmentId(EquipmentId equipmentId)
        {
            return _data.FindAll(_ => _.EquipmentId.Equals(equipmentId)).ToArray();
        }

        public void Save(Reservation entity)
        {
            var reservation = Find(entity.Id);
            
            if(reservation == null)
            {
                _data.Add(entity);
            }
        }
    }
}
