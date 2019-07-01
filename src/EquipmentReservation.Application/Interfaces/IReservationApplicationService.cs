using System;
using System.Collections.Generic;
using System.Text;
using EquipmentReservation.Application.Commands;

namespace EquipmentReservation.Application.Interfaces
{
    public interface IReservationApplicationService
    {
        void RegisterReservation(RegisterReservationCommand command);
    }
}
