using Anselme.Contatos.Domain.Aggregates;
using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Models
{
    public class CompraService
    {
        private readonly IRepository<Produto> _produtoRepository;
        private readonly IClienteRepository _clienteRepository;

        public CompraService(IRepository<Produto> produtoRepository, IClienteRepository clienteRepository)
        {
            this._produtoRepository = produtoRepository;
            this._clienteRepository = clienteRepository;
        }

        public void RegistrarNovoProduto(Produto produto)
        {
            _produtoRepository.CreateNew(produto);
        }      

        public void RegistrarNovoCliente(Cliente cliente)
        {
            _clienteRepository.CreateNew(cliente);
        }    

        public ComprovanteDeCompra EfetuarCompra(List<KeyValuePair<Produto,int>> produtosEQuantidades, Cliente cliente )
        {
            decimal precoTotal = produtosEQuantidades.Sum(i => i.Key.Preco * i.Value);


            switch(precoTotal)
            {
                case < 1000:
                    _clienteRepository.EfetuarCompra(produtosEQuantidades, cliente );
                break;

                case < 10000:
                    if(cliente is Cliente_PessoaJuridica)
                        _clienteRepository.EfetuarCompra(produtosEQuantidades, cliente );
                break;

                case < 100000:
                    if(cliente is Cliente_PessoaJuridica && ((Cliente_PessoaJuridica)cliente).Tipo != TipoDePessoaJuridica.MEI)
                        _clienteRepository.EfetuarCompra(produtosEQuantidades, cliente );
                break;

                default:
                    if(cliente is Cliente_PessoaJuridica && ((Cliente_PessoaJuridica)cliente).Tipo == TipoDePessoaJuridica.SA)
                        _clienteRepository.EfetuarCompra(produtosEQuantidades, cliente );
                break;
            }

            throw new DomainException("Operação 'EfetuarCompra' não obteve sucesso por não ter parâmetros válidos.");
        }            
    }
}