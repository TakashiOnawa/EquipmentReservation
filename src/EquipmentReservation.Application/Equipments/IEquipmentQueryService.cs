using EquipmentReservation.Application.Equipments.Queries;

namespace EquipmentReservation.Application.Equipments
{
    public interface IEquipmentQueryService
    {
        GetAllEquipmentDataResponse GetAllEquipmentData();
    }
}
