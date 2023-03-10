using API_46731r.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities.Identity;

namespace API_46731r.Services.Abstractions
{
    public interface IRoomService : IGenericService<Room>
    {
        Task<IEnumerable<Room>> GetAllWithIncludesAsync();
        Task<ComputerDTO> AddComputer(Computer computer, ApplicationUser user);
    }
}
