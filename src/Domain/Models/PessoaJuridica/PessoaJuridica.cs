namespace Anselme.Contatos.Domain.Models
{
    public class PessoaJuridica : BaseEntity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public List<Contato> Contatos{get; private set;}
        public PessoaJuridica(string nome, string email, List<Contato> contatos)
        {
            ValidaCategoria(nome, email);
            this.Nome = nome;
            this.Email = email;
            this.Contatos = contatos;
        }

        public void Update(string nome, string email)
        {
            ValidaCategoria(nome, email);
        }

        public void ValidaCategoria(string nome, string email)
        {
            if (string.IsNullOrEmpty(nome))
                throw new InvalidOperationException("Nome inválido");

            if (string.IsNullOrEmpty(email))
                throw new InvalidOperationException("Email inválido");
        }
    }
}