namespace Anselme.Contatos.Domain.Models
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
            // Nome
            DomainException.ThrowIfIsNullOrEmpty(nome,"Nome do produto vazio.");
            DomainException.ThrowIfHasSpecialCharacters(nome,"Nome do produto possui caracteres especiais");
            DomainException.ThrowIfExceedLenghts(nome,0,255,"O nome do produto ultrapassa 255 caracteres");

            // Preço
            DomainException.ThrowIfLessThenZero(preco,"O preço não pode ser menor do que zero");

            // Data de Registro
            DomainException.ThrowIfDatetimeIsLessThen(dataDeRegistro, new DateTime(2000,1,1),"A data de registro do produto não pode ser inferior a 01/01/2000");
        }
    }
}