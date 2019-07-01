using EquipmentReservation.Application.Services.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentReservation.Application.Services.Interfaces
{
    public interface IReservationApplicationService
    {
        void RegisterReservation(RegisterReservationCommand command);
    }
}
