namespace Anselme.Contatos.Infrastructure.DbEntity;

public class Telefone : BaseDbEntity
{
    public string DDI { get; set; }
    public string DDD { get; set; }
    public string Numero { get; set; }
    public string Ramal { get; set; }
}

