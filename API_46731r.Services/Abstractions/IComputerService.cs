using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.Identity;

namespace API_46731r.Services.Abstractions
{
    public interface IComputerService : IGenericService<Computer>
    {
        Task<IEnumerable<ComputerDTO>> GetAllWithIncludesAsync();
        Task<Computer> UpdateComputer(Computer entity, ApplicationUser applicationUser);
        Task<ComputerDTO> CreateComputer(Computer entity, ApplicationUser applicationUser);
    }
}
