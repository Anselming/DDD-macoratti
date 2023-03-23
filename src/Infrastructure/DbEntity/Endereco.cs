namespace Anselme.Contatos.Infrastructure.DbEntity;

public class Endereco : BaseDbEntity
{
    public string Tipo { get; set; }
    public string Nome { get; set; }
    public string Bairro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string Pais { get; set; }
    public string CodigoPostal { get; set; }
}













