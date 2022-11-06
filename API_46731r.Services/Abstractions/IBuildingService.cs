using API_46731r.Contracts;
using API_46731r.Contracts.Computer;
using API_46731r.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Services.Abstractions
{
    public interface IBuildingService : IGenericService<Building>
    {
        Task<IEnumerable<BuildingDTO>> GetAllWithIncludesAsync();
    }
}
