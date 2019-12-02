namespace EquipmentReservation.Framework.Domain
{
    public interface IValueObject
    {
        bool Equals(object obj);
        int GetHashCode();
    }
}
