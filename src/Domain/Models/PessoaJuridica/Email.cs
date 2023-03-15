namespace Anselme.Contatos.Domain.Models;

public class Email
{
    public string Nome { get; private set; }
    public string Dominio { get; private set; }

    public Email(string email)
    {
        DomainException.ThrowIfNotMatch(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", email, "E-mail inválido");
        
        this.Nome = email.Split('@')[0];
        this.Dominio = email.Split('@')[1];
    }

    public override string ToString()
    {
        return $"{Nome}{Dominio}";
    }
}