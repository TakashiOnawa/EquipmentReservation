using System;

namespace EquipmentReservation.Framework.Domain
{
    public interface IEntity<T> : IEquatable<T>
    {
    }
}
