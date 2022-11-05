using API_46731r.Contracts;
using API_46731r.Domain.Entities.Identity;

namespace API_46731r.Services.Abstractions
{
    public interface IUserService : IGenericService<ApplicationUser>
    {
        Task<ApplicationUser> GetByEmailAsync(string email);
    }
}
