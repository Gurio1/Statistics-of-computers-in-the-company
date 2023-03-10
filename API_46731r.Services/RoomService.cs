using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.Identity;
using API_46731r.Domain.Repositories;
using API_46731r.Services.Abstractions;
using AutoMapper;

namespace API_46731r.Services
{
    public class RoomService : GenericService<IRoomRepository, Room>, IRoomService
    {
        private readonly IRoomRepository _repository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository repository, IMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Room>> GetAllWithIncludesAsync()
        {
            return await _repository.GetAllWithIncludesAsync();
        }

        public async Task<ComputerDTO> AddComputer(Computer computer, ApplicationUser user)
        {
            var computerFromDB =  await _repository.AddComputer(computer,user);
            var compDTO = _mapper.Map<ComputerDTO>(computerFromDB);
            return compDTO;
        }
    }
}
