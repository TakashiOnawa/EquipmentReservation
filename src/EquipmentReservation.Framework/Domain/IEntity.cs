namespace EquipmentReservation.Framework.Domain
{
    public interface IEntity
    {
        bool Equals(object obj);
        int GetHashCode();
    }
}
