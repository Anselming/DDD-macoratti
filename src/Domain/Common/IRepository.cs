using Anselme.Contatos.Domain.Aggregates;

namespace Anselme.Contatos.Domain.Common
{
    public interface IRepository<TAggregate> where TAggregate : BaseEntity
    {
        // Create
        void CreateNew(TAggregate entity);

        // Read
        TAggregate GetById(int id);
        IEnumerable<TAggregate> GetAll();
        IEnumerable<TAggregate> GetAll(int skip, int take);

        // Update
        void Update(TAggregate entity);
        void Update(TAggregate[] entities);

        // Delete
        void Delete(TAggregate entity);
        void  Delete(TAggregate[] entities);
        void  DeleteById(int id);
        void  DeleteById(int[] ids);
        void  DeleteByCondition(Func<TAggregate,bool> condition);

    }
}