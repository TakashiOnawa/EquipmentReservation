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
            // DB コンテキストは 「ServiceLifetime.Scoped」 にし 1 リクエスト 1 インスタンスにすることで
            // ApplicationService 間で同一のコネクションを使用できるようにする。
            //services.AddDbContext<MyDbContext>(options => options.UseSqlServer("Server=J5100560;Database=EquipmentReservation;User ID=sa;Password=test!234"), ServiceLifetime.Scoped);
            services.AddDbContext<MyDbContext>(options => options.UseSqlServer("Server=DESKTOP-I2UHKUN;Database=EquipmentReservation;User ID=sa;Password=test!234"), ServiceLifetime.Scoped);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IReservationAppService, ReservationAppService>();
            services.AddTransient<IReservationQueryService, ReservationQueryService>();
            services.AddTransient<IAccountAppService, AccountAppService>();
            services.AddTransient<IAccountQueryService, AccountQueryService>();
            services.AddTransient<IEquipmentAppService, EquipmentAppService>();
            services.AddTransient<IEquipmentQueryService, EquipmentQueryService>();
        }
    }
}
