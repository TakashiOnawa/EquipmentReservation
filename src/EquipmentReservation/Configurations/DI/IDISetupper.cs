using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EquipmentReservation.Configurations.DI
{
    public interface IDISetupper
    {
        void Setup(IServiceCollection services);
    }
}
