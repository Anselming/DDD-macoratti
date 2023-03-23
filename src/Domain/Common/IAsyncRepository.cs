using System.Linq.Expressions;
using Anselme.Contatos.Domain.Aggregates;

namespace Anselme.Contatos.Domain.Common
{
    public interface IAsyncRepository<TAggregate> where TAggregate : BaseEntity
    {
        // Create
        Task CreateNewAsync(TAggregate entity);

        // Read
        Task<TAggregate> GetByIdAsync(int id);
        Task<List<TAggregate>> GetAllAsync();
        Task<List<TAggregate>> GetAllAsync(int skip, int take);
        Task<List<TAggregate>> GetByConditionAsync(Expression<Func<TAggregate,bool>> condition);
        Task<TAggregate> GetFirstByConditionAsync(Expression<Func<TAggregate,bool>> condition);

        // Update
        Task UpdateAsync(TAggregate entity);
        Task UpdateAsync(TAggregate[] entities);

        // Delete
        Task DeleteAsync(TAggregate entity);
        Task DeleteAsync(TAggregate[] entities);
        Task DeleteByIdAsync(int id);
        Task DeleteByIdAsync(int[] ids);
        Task DeleteByConditionAsync(Expression<Func<TAggregate,bool>> condition);

    }
}