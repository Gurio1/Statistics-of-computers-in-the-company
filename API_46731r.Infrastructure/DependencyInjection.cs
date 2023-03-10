using API_46731r.Domain.Repositories;
using API_46731r.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace API_46731r.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection Services)
        {
            Services.AddScoped<IComputerRepository, ComputerRepository>();
            Services.AddScoped<IRoomRepository, RoomRepository>();
            Services.AddScoped<IBuildingRepository, BuildingRepository>();
            Services.AddScoped<IUserRepository, UserRepository>();

            return Services;
        }
    }
}
