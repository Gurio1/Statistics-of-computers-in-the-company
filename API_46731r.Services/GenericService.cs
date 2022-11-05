using API_46731r.Domain.Entities;
using API_46731r.Domain.Repository;
using API_46731r.Services.Abstractions;
namespace API_46731r.Services
{
    public class GenericService<TRepository, TEntity> : IGenericService<TEntity> where TRepository
                                                     : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly TRepository repository;

        public GenericService(TRepository repository)
        {
            this.repository = repository;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            return await repository.CreateAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<bool> RemoveById(int id)
        {
            return await repository.RemoveById(id);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            return await repository.Update(entity);
        }
    }
}
