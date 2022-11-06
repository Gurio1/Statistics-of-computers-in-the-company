using API_46731r.Domain.Entities;
using API_46731r.Domain.Repositories;
using API_46731r.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Infrastructure.Repositories
{
    public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
    {
        private readonly MyProjectDbContext _context;
        public BuildingRepository(MyProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Building>> GetAllWithIncludesAsync()
        {
            return await _context.Set<Building>().AsNoTracking()
                                                 .Include(r => r.Rooms)
                                                    .ThenInclude(c =>c.Computers)
                                                        .ThenInclude(a =>a.ComputerComments)
                                                            .ThenInclude(u =>u.User)
                                                 .Include(r => r.Rooms)
                                                    .ThenInclude(c =>c.Computers)
                                                        .ThenInclude(c =>c.Characteristics)
                                                 .Include(r => r.Rooms)
                                                    .ThenInclude(c =>c.Computers)
                                                        .ThenInclude(a =>a.CheckedOn.OrderBy(t =>t.CheckedOn).Take(1))
                                                            .ThenInclude(d =>d.CheckedBy)
                                                .Include(r =>r.Rooms)
                                                    .ThenInclude(c =>c.Computers)
                                                        .ThenInclude(a =>a.ModifiedOn.OrderBy(t => t.CheckedOn).Take(1))
                                                            .ThenInclude(d =>d.CheckedBy)
                                                 .ToListAsync();
        }
    }
}
