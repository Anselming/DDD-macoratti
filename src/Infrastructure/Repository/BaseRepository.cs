using Anselme.Contatos.Domain.Aggregates;
using Anselme.Contatos.Domain.Common;
using Anselme.Contatos.Domain.Aggregates;
using Anselme.Contatos.Infrastructure.Contexts;

namespace Anselme.Contatos.Infrastructure.Repositories
{
    public abstract partial class BaseRepository<TEntity> : IRepository<TEntity>, IAsyncRepository<TEntity>
                            where TEntity : BaseEntity, IAggregateRoot
    {
        public readonly AppDbContext _context;
        
        public BaseRepository(AppDbContext context)
        {
            this._context = context;
        }


    }
}