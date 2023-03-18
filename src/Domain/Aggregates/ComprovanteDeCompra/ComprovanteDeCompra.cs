using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Aggregates
{
    public class ComprovanteDeCompra : BaseEntity, IAggregateRoot
    {
        public List<ItemDeCompra> Itens{get; private set;}
        public decimal PrecoTotal{get; private set;}
        public DateTime DataDaCompra{get; private set;}
        public int ClienteID {get; private set;}
        public string ClienteName{get; private set;}
        public string TipoDeCliente{get; private set;}


        public ComprovanteDeCompra(List<ItemDeCompra> itens, DateTime dataDaCompra, int clienteID, string clienteName, string tipoDeCliente)
        {
            var validator = new ComprovanteDeCompraValidator();
            var result = validator.Validate(this);
            DomainException.ThrowIfIsFalse(result.IsValid,$"Compra inválida: {result.ToString()}");

            this.Itens = itens;
            PrecoTotal = Itens.Sum(i => i.PrecoTotalDoItem);
            this.ClienteID = clienteID;
            this.ClienteName = clienteName;
            this.TipoDeCliente = tipoDeCliente;
        }
    }
}