using API_46731r.Domain.Entities;
using API_46731r.Domain.Repositories;
using API_46731r.Services.Abstractions;

namespace API_46731r.Services
{
    public class RoomService : GenericService<IRoomRepository, Room>, IRoomService
    {
        private readonly IRoomRepository _repository;
        public RoomService(IRoomRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Room>> GetAllWithIncludesAsync()
        {
            return await _repository.GetAllWithIncludesAsync();
        }
    }
}
