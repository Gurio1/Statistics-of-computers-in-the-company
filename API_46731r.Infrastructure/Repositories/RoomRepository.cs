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
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        private readonly MyProjectDbContext _context;
        public RoomRepository(MyProjectDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllWithIncludesAsync()
        {
            return await _context.Rooms.Include(c => c.Computers)
                                    .ThenInclude(c => c.Characteristics)
                                .Include(c => c.Computers)
                                    .ThenInclude(c => c.CheckedOn)
                                        .ThenInclude(c => c.CheckedBy)
                                .Include(c => c.Computers)
                                    .ThenInclude(c => c.ModifiedOn)
                                        .ThenInclude(c => c.CheckedBy)
                                .Include(c => c.Computers)
                                    .ThenInclude(c => c.ComputerComments)
                                        .ThenInclude(c => c.User)
                                .ToListAsync();
        }
    }
}
