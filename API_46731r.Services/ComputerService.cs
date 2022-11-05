using API_46731r.Domain.Entities;
using API_46731r.Domain.Repositories;
using API_46731r.Services.Abstractions;

namespace API_46731r.Services
{
    public class ComputerService : GenericService<IComputerRepository, Computer>, IComputerService
    {
        private readonly IComputerRepository repository;

        public ComputerService(IComputerRepository repository) : base(repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<Computer>> GetAllWithIncludesAsync()
        {
            return await repository.GetAllWithIncludesAsync();
        }
    }
}
