using Anselme.Contatos.Domain.Aggregates;
using Anselme.Contatos.Domain.Common;
using Anselme.Contatos.Infrastructure.Common;
using Anselme.Contatos.Infrastructure.Context;

namespace Anselme.Contatos.Infrastructure.Repository
{
    public class ProdutoRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
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