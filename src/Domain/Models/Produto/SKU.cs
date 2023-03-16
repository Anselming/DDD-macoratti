using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Models
{
    public class SKU
    {
        public string CodigoSKU { get; private set; }
        public decimal Preco { get; private set; }
        public string Fabricante { get; private set; }
        public string Modelo { get; private set; }
        public string Especificidade { get; private set; }
        public string Cor { get; private set; }
        public string Tamanho { get; private set; }
        public DateTime DataDegistro { get; private set; }

        public SKU(decimal preco, string fabricante, string modelo, string especificidade, string cor, string tamanho)
        {
            Validar(preco, fabricante, modelo, especificidade, cor, tamanho);
            this.Preco = preco;
            this.Fabricante = fabricante;
            this.Modelo = modelo;
            this.Especificidade = especificidade;
            this.Cor = cor;
            this.Tamanho = tamanho;

            GerarCodigoSKU();
        }

        private void GerarCodigoSKU()
        {
            this.CodigoSKU = $"{Fabricante:3}-{Modelo:3}-{Especificidade:3}-{Cor:3}-{Tamanho}";
        }

        public void Validar(decimal preco, string fabricante, string modelo, string especificidade, string cor, string tamanho)
        {
            // Preço
            DomainException.ThrowIfLessThenZero(preco, "Preço menor que zero.");

            // Fabricante
            DomainException.ThrowIfHasSpecialCharacters(fabricante, "O Fabricante possui caracteres especiais.");
            DomainException.ThrowIfIsNullOrEmpty(fabricante, "O Fabricante está vazio.");
            DomainException.ThrowIfExceedLenghts(fabricante, 0, 255, "O Fabricante possui mais de 255 caracteres.");

            // Modelo
            DomainException.ThrowIfHasSpecialCharacters(modelo, "O Modelo possui caracteres especiais.");
            DomainException.ThrowIfIsNullOrEmpty(modelo, "O Modelo está vazio.");
            DomainException.ThrowIfExceedLenghts(modelo, 0, 30, "O Modelo possui mais de 30 caracteres.");

            // Especificidade
            DomainException.ThrowIfHasSpecialCharacters(especificidade, "A especificidade possui caracteres especiais.");
            DomainException.ThrowIfExceedLenghts(especificidade, 0, 30, "A especificidade possui mais de 30 caracteres.");

            // Cor
            DomainException.ThrowIfHasSpecialCharacters(cor, "A cor possui caracteres especiais.");
            DomainException.ThrowIfExceedLenghts(cor, 0, 30, "A cor possui mais de 30 caracteres.");

            // Tamanho
            DomainException.ThrowIfExceedLenghts(tamanho, 0, 60, "Não existe tamanho menor do que zero ou maior do que 60");

        }

        public override string ToString()
        {
            return this.CodigoSKU;
        }
    }
}