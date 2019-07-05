using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Reservations.Data;

namespace EquipmentReservation.Application
{
    public interface IQueryableRepository
    {
        T QueryObject<T>(string query, params object[] arguments);
        IEnumerable<T> QueryObjects<T>(string query, params object[] arguments);
    }
}
