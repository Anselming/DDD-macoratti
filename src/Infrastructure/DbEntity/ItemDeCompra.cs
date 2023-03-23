namespace Anselme.Contatos.Infrastructure.DbEntity;

public class ItemDeCompra : BaseDbEntity
{
    public int ProdutoID { get; set; }
    public string Nome { get; set; }
    public decimal PrecoUnitario { get; set; }
    public decimal PrecoTotalDoItem { get; set; }
    public int Quantidade { get; set; }
}















//
