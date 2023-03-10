using API_46731r.Domain.Entities;
using API_46731r.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_46731r.Domain.Entities.Identity;

namespace API_46731r.Domain.Repositories
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<IEnumerable<Room>> GetAllWithIncludesAsync();
        Task<Room> GetByIdWithIncludesAsync(int id);
        Task<Computer> AddComputer(Computer computer, ApplicationUser user);
        
    }
}
