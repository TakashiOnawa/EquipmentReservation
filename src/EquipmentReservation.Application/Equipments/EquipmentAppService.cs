using System;

namespace EquipmentReservation.Application.Equipments
{
    public class EquipmentAppService : IEquipmentAppService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EquipmentAppService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
