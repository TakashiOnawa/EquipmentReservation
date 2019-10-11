using EquipmentReservation.Application;
using EquipmentReservation.Application.Accounts;
using EquipmentReservation.Application.Equipments;
using EquipmentReservation.Application.Reservations;
using EquipmentReservation.Infrastructure;
using EquipmentReservation.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentReservation.Configurations.DI
{
    public class ProductDISetupper : IDISetupper
    {
        public void Setup(IServiceCollection services)
        {
            // DB コンテキストは 「ServiceLifetime.Scoped」 にし 1 リクエスト 1 インスタンスにすることで
            // ApplicationService 間で同一のコネクションを使用できるようにする。
            services.AddDbContext<MyDbContext>(ServiceLifetime.Scoped);
            //services.AddDbContext<MyDbContext>(options => options.UseNpgsql("Host=localhost;Username=EquipmentReservation;Password=EquipmentReservation!234;Database=EquipmentReservation"), ServiceLifetime.Scoped);

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IQueryFactory, QueryFactory>();
            services.AddTransient<IReservationAppService, ReservationAppService>();
            services.AddTransient<IReservationQueryService, ReservationQueryService>();
            services.AddTransient<IAccountAppService, AccountAppService>();
            services.AddTransient<IAccountQueryService, AccountQueryService>();
            services.AddTransient<IEquipmentAppService, EquipmentAppService>();
            services.AddTransient<IEquipmentQueryService, EquipmentQueryService>();
        }
    }
}
