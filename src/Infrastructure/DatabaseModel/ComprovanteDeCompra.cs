namespace Anselme.Contatos.Infrastructure.DatabaseModel
{
    public class ComprovanteDeCompra
    {
        public List<ItemDeCompra> Itens { get; set; }
        public decimal PrecoTotal { get; set; }
        public DateTime DataDaCompra { get; set; }
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
    }
}
