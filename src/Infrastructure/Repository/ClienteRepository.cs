using Anselme.Contatos.Domain.Aggregates;
using Anselme.Contatos.Domain.Common;
using Anselme.Contatos.Domain.Models;
using Anselme.Contatos.Infrastructure.Contexts;

namespace Anselme.Contatos.Infrastructure.Repositories
{
    public class ContatoRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ContatoRepository(AppDbContext context) : base(context)
        {
        }

        public override Cliente GetById(int id)
        {
            var query = _context.Set<Cliente>().Where(e=> e.Id == id);

            if(query.Any())
                return query.First();
            return null;
        }

        public override IEnumerable<Cliente> GetAll()
        {
            var query = _context.Set<Cliente>();
            return query.Any()? query.ToList(): new List<Cliente>();
        }

        public ComprovanteDeCompra EfetuarCompra(List<KeyValuePair<Produto,int>> produtosEQuantidades, Cliente cliente )
        {
            return null;
        }
    }
}