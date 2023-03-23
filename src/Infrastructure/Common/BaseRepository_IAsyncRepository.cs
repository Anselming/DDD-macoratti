using System.Linq.Expressions;
using Anselme.Contatos.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Anselme.Contatos.Domain.Aggregates;
using Anselme.Contatos.Infrastructure.DbEntity;

namespace Anselme.Contatos.Infrastructure.Common
{
    public abstract partial class BaseRepository<TAggregate, TDBEntity> : IRepository<TAggregate>, IAsyncRepository<TAggregate>
                            where TAggregate : BaseEntity, IAggregateRoot
                            where TDBEntity : BaseDbEntity
    {
        // CREATE
        public virtual async Task CreateNewAsync(TAggregate entity)
        {
            var thisContext = _context.Set<TDBEntity>();
            await thisContext.AddAsync(ConvertAggregateToDbEntity(entity));
        }

        // READ
        public virtual async Task<TAggregate> GetByIdAsync(int id)
        {
            var thisContext = _context.Set<TDBEntity>();
            return await ConvertDbEntityToAggregate(thisContext.FindAsync(id));
        }
        public virtual async Task<List<TAggregate>> GetAllAsync()
        {
            var thisContext = _context.Set<TDBEntity>();
            return await ConvertDbEntityToAggregate(thisContext.ToListAsync());
        }
        public virtual async Task<List<TAggregate>> GetAllAsync(int skip, int take)
        {
            var thisContext = _context.Set<TDBEntity>();
            return await ConvertDbEntityToAggregate(thisContext.Skip(skip).Take(take).ToListAsync());
        }
        public virtual async Task<TAggregate> GetFirstByConditionAsync(Expression<Func<TAggregate,bool>> condition)
        {
            var context = _context.Set<TDBEntity>();
            var convertedCondition = ConvertAggregateFuncToDbEntity(condition);
            var dbEntity = context.FirstOrDefault(convertedCondition);

            return await ConvertDbEntityToAggregateinTask(dbEntity);
        }
        public virtual async Task<List<TAggregate>> GetByConditionAsync(Expression<Func<TAggregate, bool>> condition)
        {
            var context = _context.Set<TDBEntity>();
            var convertedCondition = ConvertAggregateFuncToDbEntity(condition);
            var dbEntity = context.Where(convertedCondition).ToListAsync();

            return await ConvertDbEntityToAggregate(dbEntity);
        }

    
        // UPDATE
        public virtual Task UpdateAsync(TAggregate entity)
        {
            _context.Set<TDBEntity>().Update(ConvertAggregateToDbEntity(entity));
            return Task.CompletedTask;
        }
        public virtual Task UpdateAsync(TAggregate[] entities)
        {
           _context.Set<TDBEntity>().UpdateRange(ConvertAggregateToDbEntity(entities));
            return Task.CompletedTask;
        }


        // DELETE
        public virtual Task DeleteAsync(TAggregate entity)
        {
            _context.Set<TDBEntity>().Remove(ConvertAggregateToDbEntity(entity));
            return Task.CompletedTask;
        }
        public virtual Task DeleteAsync(TAggregate[] entities)
        {
            _context.Set<TDBEntity>().RemoveRange(ConvertAggregateToDbEntity(entities));
            return Task.CompletedTask;
        }
        public virtual async Task DeleteByIdAsync(int id)
        {
            await _context.Set<TDBEntity>().Where(i => i.Id == id).ExecuteDeleteAsync();            
        }
        public virtual async Task DeleteByIdAsync(int[] ids)
        {
             await _context.Set<TDBEntity>().Where(i => ids.Contains(i.Id)).ExecuteDeleteAsync();
        }
        public virtual async Task DeleteByConditionAsync(Expression<Func<TAggregate,bool>> condition)
        {
            var context = _context.Set<TDBEntity>();
            var convertedCondition = ConvertAggregateFuncToDbEntity(condition);
            var dbEntity = context.Where(convertedCondition);

            await ConvertSimpleTask<int>(dbEntity.ExecuteDeleteAsync());
        }
    }
}