using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Aggregates
{
    public class Produto : BaseEntity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public SKU CodigoSKU { get; private set; }
        public DateTime DataDeRegistro{get; private set;}
        public DateTime? DataDeDisponibilizacao {get; private set;}
        public DateTime? DataDeRetirada {get; private set;}

        public Produto(string nome, decimal preco, SKU codigoSKU, DateTime dataDeRegistro)
        {
            Validar(nome, preco, dataDeRegistro);
            this.Nome = nome;
            this.Preco = preco;
            this.CodigoSKU = codigoSKU;
            this.DataDeRegistro = dataDeRegistro;
        }


        public void DisponibilizarProduto()
        {
            // Torna o produto disponível para compra
            this.DataDeDisponibilizacao = DateTime.Now;
        }

        public void RetirarDisponibilidadeDoProduto()
        {
            // Produto deixa de estar disponível para compra
            this.DataDeRetirada = DateTime.Now;
        }

        public void Validar(string nome, decimal preco, DateTime dataDeRegistro)
        {
            var validator = new ProdutoValidator();
            var result = validator.Validate(this);

            DomainException.ThrowIfIsFalse(result.IsValid,$"Produto inválido: {result.ToString()}");
            
        }
    }
}