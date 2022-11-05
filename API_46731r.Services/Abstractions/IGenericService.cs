using API_46731r.Domain.Entities;

namespace API_46731r.Services.Abstractions
{
    public interface IGenericService<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<bool> RemoveById(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> Update(TEntity entity);
    }
}
