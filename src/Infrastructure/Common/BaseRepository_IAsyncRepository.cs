using System.Linq.Expressions;
using Anselme.Contatos.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Anselme.Contatos.Domain.Aggregates;

namespace Anselme.Contatos.Infrastructure.Common
{
    public abstract partial class BaseRepository<TEntity> : IRepository<TEntity>, IAsyncRepository<TEntity>
                            where TEntity : BaseEntity, IAggregateRoot
    {
        // CREATE
        public virtual async Task CreateNewAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        // READ
        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public virtual async Task<List<TEntity>> GetAllAsync(int skip, int take)
        {
            return await _context.Set<TEntity>().Skip(skip).Take(take).ToListAsync();
        }
        public virtual async Task<TEntity> GetFirstByConditionAsync(Expression<Func<TEntity,bool>> condition)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(condition);
        }
        public virtual async Task<List<TEntity>> GetByConditionAsync(Expression<Func<TEntity, bool>> condition)
        {
            return await _context.Set<TEntity>().Where(condition).ToListAsync();
        }

    
        // UPDATE
        public virtual Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            return Task.CompletedTask;
        }
        public virtual Task UpdateAsync(TEntity[] entities)
        {
           _context.Set<TEntity>().UpdateRange(entities);
            return Task.CompletedTask;
        }


        // DELETE
        public virtual Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return Task.CompletedTask;
        }
        public virtual Task DeleteAsync(TEntity[] entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            return Task.CompletedTask;
        }
        public virtual async Task DeleteByIdAsync(int id)
        {
            await _context.Set<TEntity>().Where(i => i.Id == id).ExecuteDeleteAsync();            
        }
        public virtual async Task DeleteByIdAsync(int[] ids)
        {
             await _context.Set<TEntity>().Where(i => ids.Contains(i.Id)).ExecuteDeleteAsync();
        }
        public virtual async Task DeleteByConditionAsync(Expression<Func<TEntity,bool>> condition)
        {
            await _context.Set<TEntity>().Where(condition).ExecuteDeleteAsync();
        }
    }
}