namespace Anselme.Contatos.Domain.Models
{
    public class ItemDeCompra : BaseEntity
    {
        public string Nome { get; private set; }
        public decimal Preco{get; private set;}
        public ItemDeCompra(string nome, decimal preco)
        {
            Validar(nome, preco);
            this.Nome = nome;
            this.Preco = preco;
        }

        public void Validar(string nome, decimal preco)
        {

        }
    }
}