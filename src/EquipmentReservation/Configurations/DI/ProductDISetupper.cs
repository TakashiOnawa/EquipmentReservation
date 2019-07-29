using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentReservation.Application;
using EquipmentReservation.Application.Accounts;
using EquipmentReservation.Application.Accounts.Queries;
using EquipmentReservation.Application.Equipments;
using EquipmentReservation.Application.Equipments.Queries;
using EquipmentReservation.Application.Reservations;
using EquipmentReservation.Application.Reservations.Queries;
using EquipmentReservation.Domain.Accounts;
using EquipmentReservation.Domain.Equipments;
using EquipmentReservation.Domain.Reservations;
using EquipmentReservation.Infrastructure;
using EquipmentReservation.Infrastructure.Application.Repositories;
using EquipmentReservation.Infrastructure.Database;
using EquipmentReservation.Infrastructure.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentReservation.Configurations.DI
{
    public class ProductDISetupper : IDISetupper
    {
        public void Setup(IServiceCollection services)
        {
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IReservationDataQuery, ReservationDataQuery>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IAccountDataQuery, AccountDataQuery>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentDataQuery, EquipmentDataQuery>();
            services.AddScoped<IReservationAppService, ReservationAppService>();
            services.AddScoped<IReservationQueryService, ReservationQueryService>();
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddScoped<IAccountQueryService, AccountQueryService>();
            services.AddScoped<IEquipmentAppService, EquipmentAppService>();
            services.AddScoped<IEquipmentQueryService, EquipmentQueryService>();
            //services.AddDbContext<MyDbContext>(options => options.UseSqlServer("Server=J5100560;Database=EquipmentReservation;User ID=sa;Password=test!234"), ServiceLifetime.Scoped);
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer("Server=DESKTOP-I2UHKUN;Database=EquipmentReservation;User ID=sa;Password=test!234"), ServiceLifetime.Scoped);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
