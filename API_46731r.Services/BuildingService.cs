using API_46731r.Contracts;
using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using API_46731r.Domain.Repositories;
using API_46731r.Services.Abstractions;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Services
{
    public class BuildingService : GenericService<IBuildingRepository, Building>, IBuildingService
    {
        private readonly IBuildingRepository _repository;
        private readonly IMapper _mapper;
        public BuildingService(IBuildingRepository repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<BuildingDTO>> GetAllWithIncludesAsync()
        {
           var buildings = await _repository.GetAllWithIncludesAsync();

           var b = _mapper.Map<List<BuildingDTO>>(buildings);

            return b;
        }

        public async Task<Room> AddRoom(Room room)
        {
            return await _repository.AddRoom(room);
        }
    }
}
