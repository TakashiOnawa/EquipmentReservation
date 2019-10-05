using Microsoft.Extensions.DependencyInjection;

namespace EquipmentReservation.Configurations.DI
{
    public interface IDISetupper
    {
        void Setup(IServiceCollection services);
    }
}
