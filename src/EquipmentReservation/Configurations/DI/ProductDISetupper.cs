using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentReservation.Application;
using EquipmentReservation.Application.Accounts;
using EquipmentReservation.Application.Equipments;
using EquipmentReservation.Application.Reservations;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;
using EquipmentReservation.Infrastructure.Application.Repositories;
using EquipmentReservation.Infrastructure.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentReservation.Configurations.DI
{
    public class ProductDISetupper : IDISetupper
    {
        public void Setup(IServiceCollection services)
        {
            services.AddSingleton<IQueryableRepository, QueryableRepository>();
            services.AddSingleton<IReservationRepository, ReservationRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<IEquipmentRepository, EquipmentRepository>();
            services.AddSingleton<IReservationQueryService, ReservationQueryService>();
            services.AddSingleton<IReservationAppService, ReservationAppService>();
            services.AddSingleton<IAccountAppService, AccountAppService>();
            services.AddSingleton<IEquipmentAppService, EquipmentAppService>();
        }
    }
}
