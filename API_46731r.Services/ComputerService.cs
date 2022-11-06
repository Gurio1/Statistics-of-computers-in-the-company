using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Domain.Repositories;
using API_46731r.Services.Abstractions;
using AutoMapper;

namespace API_46731r.Services
{
    public class ComputerService : GenericService<IComputerRepository, Computer>, IComputerService
    {
        private readonly IComputerRepository repository;
        private readonly IMapper _mapper;

        public ComputerService(IComputerRepository repository, IMapper mapper) : base(repository)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComputerDTO>> GetAllWithIncludesAsync()
        {
            var comps = await repository.GetAllWithIncludesAsync();

            var mappedComps = _mapper.Map<List<ComputerDTO>>(comps);

            return mappedComps;
        }
    }
}
