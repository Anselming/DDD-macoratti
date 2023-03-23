using Anselme.Contatos.Domain.Aggregates;
using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Models
{
    public class CompraService
    {
        private readonly IRepository<ComprovanteDeCompra> _comprovanteDeCompraRepository;
        public CompraService(IRepository<ComprovanteDeCompra> comprovanteDeCompraRepository)
        {
            this._comprovanteDeCompraRepository = comprovanteDeCompraRepository;
        }


        public ComprovanteDeCompra EfetuarCompra(List<ItemDeCompra> itens, Cliente cliente )
        {
            ComprovanteDeCompra comprovante_nao_emitido = new ComprovanteDeCompra(itens, DateTime.Now, cliente.Id, cliente.NomeDoCliente.ObterNomeComPronome(), cliente.GetType().ToString());
            decimal precoTotal = itens.Sum(i => i.PrecoTotalDoItem);

            switch(precoTotal)
            {
                case < 1000:
                    _comprovanteDeCompraRepository.CreateNew(comprovante_nao_emitido);
                    
                break;

                case < 10000:
                    if(cliente is Cliente_PessoaJuridica)
                        _comprovanteDeCompraRepository.CreateNew(comprovante_nao_emitido);
                break;

                case < 100000:
                    if(cliente is Cliente_PessoaJuridica && ((Cliente_PessoaJuridica)cliente).Tipo != TipoDePessoaJuridica.MEI)
                        _comprovanteDeCompraRepository.CreateNew(comprovante_nao_emitido);
                break;

                default:
                    if(cliente is Cliente_PessoaJuridica && ((Cliente_PessoaJuridica)cliente).Tipo == TipoDePessoaJuridica.SA)
                        _comprovanteDeCompraRepository.CreateNew(comprovante_nao_emitido);
                break;
            }

            throw new DomainException("Operação 'EfetuarCompra' não obteve sucesso por não ter parâmetros válidos.");
        }            
    }
}