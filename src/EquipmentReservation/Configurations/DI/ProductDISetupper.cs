using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentReservation.Application.Services;
using EquipmentReservation.Application.Services.Interfaces;
using EquipmentReservation.Domain.Reservations;
using EquipmentReservation.Infrastructure.Domain.Reservations;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentReservation.Configurations.DI
{
    public class ProductDISetupper : IDISetupper
    {
        public void Setup(IServiceCollection services)
        {
            services.AddSingleton<IReservationRepository, ReservationRepository>();
            services.AddSingleton<IReservationApplicationService, ReservationApplicationService>();
        }
    }
}
