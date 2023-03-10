using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.ComputerState;
using API_46731r.Domain.Entities.Identity;
using API_46731r.Domain.Repositories;
using API_46731r.Services.Abstractions;
using AutoMapper;

namespace API_46731r.Services
{
    public class ComputerService : GenericService<IComputerRepository, Computer>, IComputerService
    {
        private readonly IComputerRepository _repository;
        private readonly IMapper _mapper;

        public ComputerService(IComputerRepository repository, IMapper mapper) : base(repository)
        {
            this._repository = repository;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<ComputerDTO>> GetAllWithIncludesAsync()
        {
            var comps = await _repository.GetAllWithIncludesAsync();

            var mappedComps = _mapper.Map<List<ComputerDTO>>(comps);

            return mappedComps;
        }
        
        public async Task<Computer> GetByIdWithIncludesAsync(int id)
        {
            var comp = await _repository.GetByIdWithIncludesAsync(id);

            return comp;
        }
        
        public async Task<Computer> UpdateComputer(Computer entity,ApplicationUser applicationUser)
        {
            return await _repository.UpdateComputer(entity,applicationUser);
        }
        
        public async Task<ComputerDTO> CreateComputer(Computer entity,ApplicationUser applicationUser)
        {
            var computerFromDB = await _repository.CreateComputer(entity,applicationUser);
            var compDTO = _mapper.Map<ComputerDTO>(computerFromDB);
            return compDTO;
        }
    }
}
