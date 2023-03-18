namespace Anselme.Contatos.Infrastructure.DatabaseModel
{
 public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataDeRegistro{get; set;}
        public DateTime? DataDeDisponibilizacao {get; set;}
        public DateTime? DataDeRetirada {get; set;}
        public string SKUCodigo { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public string Especificidade { get; set; }
        public string Cor { get; private set; }
        public string Tamanho { get; private set; }
        public DateTime DataDegistro { get; set; }
    }
}
