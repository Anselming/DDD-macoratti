namespace Anselme.Contatos.Infrastructure.DbEntity;

public class Cliente : BaseDbEntity
{
    public string Email { get; set; }
    public List<Telefone> Telefones { get; set; }
    public Telefone TelefonePrincipal { get; set; }
    public List<Endereco> Enderecos { get; set; }
    public Endereco EnderecoPrincipal { get; set; }

    //------------

    public string PrimeiroNome { get; set; }
    public string NomeDoMeio { get; set; }
    public string UltimoNome { get; set; }
    public string Titulo { get; set; }
    public string Pronome { get; set; }
    public string Apelido { get; set; }
    public string ComoPrefereSerChamado { get; set; }

    // ------------
}

