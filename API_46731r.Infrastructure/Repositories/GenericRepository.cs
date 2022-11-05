using API_46731r.Domain.Entities;
using API_46731r.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace API_46731r.Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly MyProjectDbContext context;

        public GenericRepository(MyProjectDbContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} can not be added! :{ex.Message}");
            }



        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve entities : {ex.Message}");
            }

        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            try
            {
                var entity = await context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefaultAsync();

                if (entity is null)
                {
                    throw new Exception($"Could not find entity with Id ={id}");
                }

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retrieve entity : {ex.Message}");
            }

        }

        public async Task<bool> RemoveById(int id)
        {
            var entity = await context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefaultAsync();

            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            try
            {
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not delete {nameof(entity)} with id {id} : {ex.Message}");
            }



        }

        public async Task<TEntity> Update(TEntity entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            context.Entry(entity).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not update entity with id = {entity.Id} : {ex.Message}");
            }
        }
    }
}
