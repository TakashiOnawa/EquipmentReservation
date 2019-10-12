using System;

namespace EquipmentReservation.Framework.Domain
{
    public interface IValueObject<T> : IEquatable<T>
    {
    }
}
