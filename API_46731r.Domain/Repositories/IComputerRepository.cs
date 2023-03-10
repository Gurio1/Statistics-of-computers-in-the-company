using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.Identity;
using API_46731r.Domain.Repository;

namespace API_46731r.Domain.Repositories
{
    public interface IComputerRepository : IGenericRepository<Computer>
    {
        Task<IEnumerable<Computer>> GetAllWithIncludesAsync();
        Task<Computer> GetByIdWithIncludesAsync(int id);
        Task<Computer> UpdateComputer(Computer computer, ApplicationUser user);

        Task<Computer> CreateComputer(Computer computer, ApplicationUser user);
    }
}
