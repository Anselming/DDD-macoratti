using Anselme.Contatos.Domain.Models;

namespace Anselme.Contatos.Domain.Common
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        // Create
        void CreateNew(TEntity entity);

        // Read
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetAll(int skip, int take);

        // Update
        void Update(TEntity entity);
        void Update(TEntity[] entities);

        // Delete
        void Delete(TEntity entity);
        void  Delete(TEntity[] entities);
        void  DeleteById(int id);
        void  DeleteById(int[] ids);
        void  DeleteByCondition(Func<TEntity,bool> condition);

    }
}