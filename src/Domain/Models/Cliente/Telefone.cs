using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Models;
public class Telefone
{
    public string DDI { get; private set; }
    public string DDD { get; private set; }
    public string Numero { get; private set; }
    public string Ramal { get; private set; }
    public Telefone(string ddi, string? ddd, string numero, string ramal)
    {
        DomainException.ThrowIfNotMatch(@"\d[1,4]", ddi, "DDI inválido");

        if (ddi == "55")
        {
            DomainException.ThrowIfIsNullOrEmpty(ddd, "DDD não preenchido");
            DomainException.ThrowIfNotMatch(@"\d[0,2]", ddd, "DDD inválido");
        }

        DomainException.ThrowIfNotMatch(@"\d", numero, "número inválido");
        DomainException.ThrowIfNotMatch(@"\d", ramal, "Ramal inválido");

        this.DDI = ddi;
        this.DDD = ddd;
        this.Numero = numero;
        this.Ramal = ramal;
    }

    public string ObterTelefone(bool incluirRamal = false)
    {
        if(incluirRamal)
            return (DDI == "55") ? $"+{DDI} {DDD} {Numero} ({Ramal})" : $"+{DDI} {Numero} ({Ramal})";
        else
            return (DDI == "55") ? $"+{DDI} {DDD} {Numero}" : $"+{DDI} {Numero}";
    }

}