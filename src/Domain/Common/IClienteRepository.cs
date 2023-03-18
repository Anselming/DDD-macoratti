using Anselme.Contatos.Domain.Aggregates;

namespace Anselme.Contatos.Domain.Common
{
    public interface IClienteRepository: IRepository<Cliente>
    {
        ComprovanteDeCompra EfetuarCompra(List<KeyValuePair<Produto,int>> produtosEQuantidades, Cliente cliente );
    }
}