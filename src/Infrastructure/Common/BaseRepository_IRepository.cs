using Anselme.Contatos.Domain.Common;
using Anselme.Contatos.Domain.Aggregates;
using Anselme.Contatos.Infrastructure.DbEntity;


namespace Anselme.Contatos.Infrastructure.Common
{
    public abstract partial class BaseRepository<TAggregate, TDBEntity> : IRepository<TAggregate>, IAsyncRepository<TAggregate>
                            where TAggregate : BaseEntity, IAggregateRoot
                            where TDBEntity : BaseDbEntity
    {
        // CREATE
        public virtual void CreateNew(TAggregate entity)
        {
            var thisContext = _context.Set<TDBEntity>();
            thisContext.Add(ConvertAggregateToDbEntity(entity));
        }

        // READ
        public virtual TAggregate GetById(int id)
        {
            var dbEntity = _context.Set<TDBEntity>().Where(e => e.Id == id).FirstOrDefault();
            return ConvertDbEntityToAggregate(dbEntity);
        }
        public virtual IEnumerable<TAggregate> GetAll()
        {
            var dbEntity = _context.Set<TDBEntity>().AsEnumerable();
            return ConvertDbEntityToAggregate(dbEntity);
        }
        public virtual IEnumerable<TAggregate> GetAll(int skip, int take)
        {
            var dbEntity = _context.Set<TDBEntity>().Skip(skip).Take(take).AsEnumerable();
            return ConvertDbEntityToAggregate(dbEntity);
        }
        public virtual IEnumerable<TAggregate> GetByCondition(Func<TAggregate, bool> condition)
        {
            var context = _context.Set<TDBEntity>();
            var convertedCondition = ConvertAggregateFuncToDbEntity(condition);
            var dbEntity = context.Where(convertedCondition);

            return ConvertDbEntityToAggregate(dbEntity);
        }
        public TAggregate GetFirstByCondition(Func<TDBEntity, bool> condition)
        {
            var dbEntity = _context.Set<TDBEntity>().Where(condition).FirstOrDefault();
            return ConvertDbEntityToAggregate(dbEntity);
        }


        // UPDATE
        public void Update(TAggregate entity)
        {
            _context.Set<TDBEntity>().Update(ConvertAggregateToDbEntity(entity));
        }
        public void Update(TAggregate[] entities)
        {
            _context.Set<TDBEntity>().UpdateRange(ConvertAggregateToDbEntity(entities));
        }


        // DELETE
        public void Delete(TAggregate entity)
        {
            _context.Set<TDBEntity>().Remove( ConvertAggregateToDbEntity(entity));
        }
        public void DeleteById(int id)
        {
            DeleteByCondition(c => c.Id == id);
        }
        public void DeleteByCondition(Func<TAggregate, bool> condition)
        {
            var context = _context.Set<TDBEntity>();
            var convertedCondition = ConvertAggregateFuncToDbEntity(condition);

            var itemsToRemove = context.Where(convertedCondition);
            context.RemoveRange(itemsToRemove);
        }
        public void Delete(TAggregate[] entities)
        {
            _context.Set<TDBEntity>().RemoveRange(ConvertAggregateToDbEntity(entities));
        }
        public void DeleteById(int[] ids)
        {
            DeleteByCondition(c => ids.Contains(c.Id));
        }



      
    }
}