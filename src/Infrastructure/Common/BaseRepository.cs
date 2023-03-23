using System.Linq.Expressions;
using Anselme.Contatos.Domain.Aggregates;
using Anselme.Contatos.Domain.Common;
using Anselme.Contatos.Infrastructure.Context;
using Anselme.Contatos.Infrastructure.DbEntity;

namespace Anselme.Contatos.Infrastructure.Common
{
    public abstract partial class BaseRepository<TAggregate, TDBEntity> : IRepository<TAggregate>, IAsyncRepository<TAggregate>
                            where TAggregate : BaseEntity, IAggregateRoot
                            where TDBEntity : BaseDbEntity
    {
        public readonly AppDbContext _context;
        
        public BaseRepository(AppDbContext context)
        {
            this._context = context;
        }

        private TDBEntity ConvertAggregateToDbEntity(TAggregate entity)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<TDBEntity>(entity);
        }

        private IEnumerable<TDBEntity> ConvertAggregateToDbEntity(IEnumerable<TAggregate> entity)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<IEnumerable<TDBEntity>>(entity);
        }        

        private TAggregate ConvertDbEntityToAggregate(TDBEntity dbEntity)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<TAggregate>(dbEntity);
        }

        private Task<TAggregate> ConvertDbEntityToAggregateinTask(TDBEntity dbEntity)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<Task<TAggregate>>(dbEntity);
        }        

        private IEnumerable<TAggregate> ConvertDbEntityToAggregate(IEnumerable<TDBEntity> dbEntity)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<IEnumerable<TAggregate>>(dbEntity);
        }  

        private Task<TAggregate> ConvertDbEntityToAggregate(ValueTask<TDBEntity> dbEntity)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<Task<TAggregate>>(dbEntity);
        }       

        private Task<TAggregate> ConvertDbEntityToAggregate(Task<TDBEntity> dbEntity)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<Task<TAggregate>>(dbEntity);
        }              

        private Task<List<TAggregate>> ConvertDbEntityToAggregate(Task<List<TDBEntity>> dbEntity)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<Task<List<TAggregate>>>(dbEntity);
        }     

        private Task ConvertSimpleTask<T>(Task<T> dbEntity)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<Task>(dbEntity);
        }     


        private Func<TDBEntity, bool> ConvertAggregateFuncToDbEntity(Func<TAggregate, bool> condition)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<Func<TDBEntity, bool>>(condition);
        }             
        private Expression<Func<TDBEntity, bool>> ConvertAggregateFuncToDbEntity(Expression<Func<TAggregate, bool>> condition)
        {
            DbEntityProfileMapper profile = new DbEntityProfileMapper();
            var mapper = profile.GetMap().CreateMapper();
            return mapper.Map<Expression<Func<TDBEntity, bool>>>(condition);
        }          

    }
}