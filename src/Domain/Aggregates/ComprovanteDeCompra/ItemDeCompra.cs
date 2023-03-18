
using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Aggregates
{
    public class ItemDeCompra : BaseEntity
    {
        public int ProdutoID{get; private set;}        
        public string Nome{get; private set;}
        public decimal PrecoUnitario{get; private set;}
        public decimal PrecoTotalDoItem{get; private set;}
        public int Quantidade {get; private set;}

        public ItemDeCompra(int produtoID, string nome, decimal precoUnitario, int quantidade)
        {
            var validator = new ItemDeCompraValidator();
            var result = validator.Validate(this);
            DomainException.ThrowIfIsFalse(result.IsValid,$"Compra inválida: {result.ToString()}");

            this.ProdutoID = produtoID;
            this.Nome = nome;
            this.PrecoUnitario = precoUnitario;
            this.PrecoTotalDoItem = precoUnitario * quantidade;
            this.Quantidade = quantidade;
        }

    }
}