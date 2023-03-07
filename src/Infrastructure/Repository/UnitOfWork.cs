using Anselme.Contatos.Domain.Interfaces;
using Anselme.Contatos.Infrastructure.Contexts;

namespace Anselme.Contatos.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}