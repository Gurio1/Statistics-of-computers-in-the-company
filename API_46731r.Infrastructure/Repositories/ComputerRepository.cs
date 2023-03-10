using API_46731r.Domain.Entities;
using API_46731r.Domain.Entities.ComputerState;
using API_46731r.Domain.Entities.Identity;
using API_46731r.Domain.Repositories;
using API_46731r.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace API_46731r.Infrastructure.Repositories
{
    public class ComputerRepository : GenericRepository<Computer>, IComputerRepository
    {
        private readonly MyProjectDbContext context;

        public ComputerRepository(MyProjectDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Computer>> GetAllWithIncludesAsync()
        {
            try
            {
                return await context.Set<Computer>().AsNoTracking().Include(c =>c.Characteristics)
                                                                   .Include(t =>t.ModifiedOn)
                                                                        .ThenInclude(c =>c.CheckedBy)
                                                                   .Include(t =>t.CheckedOn)
                                                                        .ThenInclude(c => c.CheckedBy)
                                                                   .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve entities : {ex.Message}");
            }

        }
        

        public async Task<Computer?> GetByIdWithIncludesAsync(int id)
        {
            try
            {
                return await context.Set<Computer>().Where(c =>c.Id == id). Include(c =>c.Characteristics)
                    .Include(t =>t.ModifiedOn)!
                    .ThenInclude(c =>c.CheckedBy)
                    .Include(t =>t.CheckedOn)!
                    .ThenInclude(c => c.CheckedBy)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve entities : {ex.Message}");
            }

        }
        
        public async Task<Computer> UpdateComputer(Computer computer,ApplicationUser user)
        {
            try
            {
                var compFromDB = await GetByIdWithIncludesAsync(computer.Id);
                compFromDB.State = computer.State;
                compFromDB.Characteristics.Processor = computer.Characteristics.Processor;
                compFromDB.Characteristics.RAM = computer.Characteristics.RAM;
                compFromDB.Characteristics.Storage = computer.Characteristics.Storage;
                compFromDB.Characteristics.MotherBoard = computer.Characteristics.MotherBoard;
                compFromDB.Mac = computer.Mac;
                compFromDB.HostName = computer.HostName;
                compFromDB.InventoryNumber = computer.InventoryNumber;
                compFromDB.ModifiedOn.Add(new ComputerModifiedOn(){CheckedOn = DateTime.Now,CheckedBy = user});

                context.Update(compFromDB);
                await context.SaveChangesAsync();
                return compFromDB;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve entities : {ex.Message}");
            }

        }
        
        public async Task<Computer> CreateComputer(Computer computer,ApplicationUser user)
        {
            
            if (computer is null)
            {
                throw new ArgumentNullException(nameof(computer));
            }

            try
            {
                computer.ModifiedOn = new List<ComputerModifiedOn>();
                computer.CheckedOn = new List<ComputerCheckedOn>();
                computer.ModifiedOn.Add(new ComputerModifiedOn(){CheckedOn = DateTime.Now,CheckedBy = user});
                computer.CheckedOn.Add(new ComputerCheckedOn(){CheckedOn = DateTime.Now,CheckedBy = user});
                
                await context.Computers.AddAsync(computer);
                await context.SaveChangesAsync();
                return computer;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(computer)} can not be added! :{ex.Message}");
            }
        }
    }
}
