using API_46731r.Domain.Entities;

namespace API_46731r.Services.Abstractions
{
    public interface IComputerService : IGenericService<Computer>
    {
        Task<IEnumerable<Computer>> GetAllWithIncludesAsync();
    }
}
