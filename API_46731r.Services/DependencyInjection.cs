using API_46731r.Domain.Entities.Identity;
using API_46731r.Services.Abstractions;
using API_46731r.Services.Abstractions.Authentication;
using API_46731r.Services.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API_46731r.Services
{
    public static partial class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection Services, IConfiguration configuration)
        {
            Services.AddScoped<IPasswordHasher<ApplicationUser>, PasswordHasher<ApplicationUser>>();
            Services.AddScoped<IComputerService, ComputerService>();
            Services.AddScoped<IRoomService, RoomService>();
            Services.AddScoped<IBuildingService, BuildingService>();
            Services.AddScoped<IUserService, UserService>();
            Services.AddScoped<IAuthenticationService, AuthenticationService>();

            Services.AddSingleton<ITokenService,TokenService>();

            return Services;
        }
    }
}
