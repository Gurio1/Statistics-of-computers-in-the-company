using API_46731r.Contracts;
using API_46731r.Domain.Entities.Identity;
using API_46731r.Services.Authentication;

namespace API_46731r.Services.Abstractions.Authentication
{
    public interface IAuthenticationService
    {
        Task<ApplicationUser> LogIn(ApplicationUserViewModel userVM);
    }
}
