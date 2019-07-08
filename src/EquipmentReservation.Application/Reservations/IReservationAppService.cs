using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Reservations.Commands;

namespace EquipmentReservation.Application.Reservations
{
    public interface IReservationAppService
    {
        void RegisterReservation(RegisterReservationRequest request);
        void ChangeReservationInfo(ChangeReservationInfoRequest request);
    }
}
