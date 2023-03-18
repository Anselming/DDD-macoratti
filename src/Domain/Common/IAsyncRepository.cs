using System.Linq.Expressions;
using Anselme.Contatos.Domain.Aggregates;

namespace Anselme.Contatos.Domain.Common
{
    public interface IAsyncRepository<TEntity> where TEntity : BaseEntity
    {
        // Create
        Task CreateNewAsync(TEntity entity);

        // Read
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(int skip, int take);
        Task<List<TEntity>> GetByConditionAsync(Expression<Func<TEntity,bool>> condition);
        Task<TEntity> GetFirstByConditionAsync(Expression<Func<TEntity,bool>> condition);

        // Update
        Task UpdateAsync(TEntity entity);
        Task UpdateAsync(TEntity[] entities);

        // Delete
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(TEntity[] entities);
        Task DeleteByIdAsync(int id);
        Task DeleteByIdAsync(int[] ids);
        Task DeleteByConditionAsync(Expression<Func<TEntity,bool>> condition);

    }
}