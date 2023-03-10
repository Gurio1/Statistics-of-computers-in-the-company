using API_46731r.Domain.Entities;
using API_46731r.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Domain.Repositories
{
    public interface IBuildingRepository : IGenericRepository<Building>
    {
        Task<IEnumerable<Building>> GetAllWithIncludesAsync();
        Task<Room> AddRoom(Room room);
    }
}
