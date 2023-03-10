using API_46731r.Domain.Entities;
using API_46731r.Domain.Repositories;
using API_46731r.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_46731r.Domain.Entities.ComputerState;
using API_46731r.Domain.Entities.Identity;

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
        
        public async Task<Room> GetByIdWithIncludesAsync(int id)
        {
            try
            {
                return await _context.Set<Room>().Where(c =>c.Id == id)
                    .Include(c =>c.Computers)
                        .ThenInclude(c =>c.Characteristics)
                    .Include(c =>c.Computers)
                        .ThenInclude(t =>t.ModifiedOn)!
                            .ThenInclude(c =>c.CheckedBy)
                    .Include(c =>c.Computers)
                        .ThenInclude(t =>t.CheckedOn)!
                            .ThenInclude(c => c.CheckedBy)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve entities : {ex.Message}");
            }

        }
        
        public async Task<Computer> AddComputer(Computer computer,ApplicationUser user)
        {
            
            if (computer is null || user is null )
            {
                throw new ArgumentNullException();
            }

            try
            {
                computer.ModifiedOn = new List<ComputerModifiedOn>();
                computer.CheckedOn = new List<ComputerCheckedOn>();
                computer.ModifiedOn.Add(new ComputerModifiedOn(){CheckedOn = DateTime.Now,CheckedBy = user});
                computer.CheckedOn.Add(new ComputerCheckedOn(){CheckedOn = DateTime.Now,CheckedBy = user});

                var room = await GetByIdWithIncludesAsync(computer.RoomId);
                room.Computers.Add(computer);
                
                await _context.SaveChangesAsync();
                return computer;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(computer)} can not be added! :{ex.Message}");
            }
        }
    }
}
