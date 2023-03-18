using Anselme.Contatos.Domain.Common;
using Anselme.Contatos.Domain.Aggregates;
using Anselme.Contatos.Infrastructure.Contexts;

namespace Anselme.Contatos.Infrastructure.Repositories
{
    public abstract partial class BaseRepository<TEntity> : IRepository<TEntity>, IAsyncRepository<TEntity>
                            where TEntity : BaseEntity, IAggregateRoot
    {
        // CREATE
        public virtual void CreateNew(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        // READ
        public virtual TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Where(e=> e.Id == id).FirstOrDefault();
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }
        public virtual IEnumerable<TEntity> GetAll(int skip, int take)
        {
            return _context.Set<TEntity>().Skip(skip).Take(take).AsEnumerable();
        }
        public virtual IEnumerable<TEntity> GetByCondition(Func<TEntity,bool> condition)
        {
            return _context.Set<TEntity>().Where(condition);
        }        
        public TEntity GetFirstByCondition(Func<TEntity,bool> condition)
        {
            return _context.Set<TEntity>().Where(condition).FirstOrDefault();
        }


        // UPDATE
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        public void Update(TEntity[] entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
        }


        // DELETE
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void DeleteById(int id)
        {
            DeleteByCondition(c => c.Id == id);
        }
        public void DeleteByCondition(Func<TEntity,bool> condition)
        {
            _context.Set<TEntity>().RemoveRange(_context.Set<TEntity>().Where(condition));
        }
        public void Delete(TEntity[] entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        public void DeleteById(int[] ids)
        {
            DeleteByCondition(c => ids.Contains(c.Id));
        }
    }
}