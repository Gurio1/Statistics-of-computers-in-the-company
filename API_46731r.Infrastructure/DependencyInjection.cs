using API_46731r.Domain.Repositories;
using API_46731r.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection Services)
        {
            Services.AddScoped<IComputerRepository, ComputerRepository>();
            Services.AddScoped<IBuildingRepository, BuildingRepository>();
            Services.AddScoped<IUserRepository, UserRepository>();

            return Services;
        }
    }
}
