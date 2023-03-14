namespace Anselme.Contatos.Domain.Models
{
    public class Contato : BaseEntity
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Contato(string nome, string email)
        {
            ValidaCategoria(nome, email);
            this.Nome = nome;
            this.Email = email;
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