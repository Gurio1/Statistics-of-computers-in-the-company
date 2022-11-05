using API_46731r.Domain.Entities;
using API_46731r.Domain.Repository;

namespace API_46731r.Domain.Repositories
{
    public interface IComputerRepository : IGenericRepository<Computer>
    {
        Task<IEnumerable<Computer>> GetAllWithIncludesAsync();
    }
}
