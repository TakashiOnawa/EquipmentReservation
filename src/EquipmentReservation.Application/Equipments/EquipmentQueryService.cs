using EquipmentReservation.Application.Equipments.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Equipments
{
    public class EquipmentQueryService : IEquipmentQueryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EquipmentQueryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public GetAllEquipmentDataResponse GetAllEquipmentData()
        {
            return new GetAllEquipmentDataResponse()
            {
                EquipmentDataList = _unitOfWork.EquipmentDataQuery.FindAllEquipmentData()
            };
        }
    }
}
