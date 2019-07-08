using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentReservation.Application.Accounts;
using EquipmentReservation.Application.Accounts.Queries;
using EquipmentReservation.Application.Equipments;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Application.Reservations;
using EquipmentReservation.Application.Reservations.Queries;
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
            services.AddSingleton<IReservationRepository, ReservationRepository>();
            services.AddSingleton<IReservationDataQuery, ReservationDataQuery>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
            services.AddSingleton<IAccountDataQuery, AccountDataQuery>();
            services.AddSingleton<IEquipmentRepository, EquipmentRepository>();
            services.AddSingleton<IEquipmentDataQuery, EquipmentDataQuery>();
            services.AddSingleton<IReservationAppService, ReservationAppService>();
            services.AddSingleton<IReservationQueryService, ReservationQueryService>();
            services.AddSingleton<IAccountAppService, AccountAppService>();
            services.AddSingleton<IAccountQueryService, AccountQueryService>();
            services.AddSingleton<IEquipmentAppService, EquipmentAppService>();
            services.AddSingleton<IEquipmentQueryService, EquipmentQueryService>();
        }
    }
}
