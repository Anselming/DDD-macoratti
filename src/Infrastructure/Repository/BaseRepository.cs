using Anselme.Contatos.Domain.Interfaces;
using Anselme.Contatos.Domain.Models;
using Anselme.Contatos.Infrastructure.Contexts;

namespace Anselme.Contatos.Infrastructure.Repositories
{
    public abstract partial class BaseRepository<TEntity> : IRepository<TEntity>, IAsyncRepository<TEntity>
                            where TEntity : BaseEntity
    {
        public readonly AppDbContext _context;
        
        public BaseRepository(AppDbContext context)
        {
            this._context = context;
        }

    }
}