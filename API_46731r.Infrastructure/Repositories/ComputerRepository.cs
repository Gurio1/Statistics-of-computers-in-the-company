using API_46731r.Domain.Entities;
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
    }
}
