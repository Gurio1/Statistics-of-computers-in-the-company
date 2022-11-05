using API_46731r.Domain.Entities.Identity;
using API_46731r.Domain.Repository;

namespace API_46731r.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetByEmailAsync(string userName);
    }
}
