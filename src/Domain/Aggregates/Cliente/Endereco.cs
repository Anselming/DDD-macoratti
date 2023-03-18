using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Aggregates;
public class Endereco
{
    public TipoDeEndereco Tipo { get; private set; }
    public string Nome { get; private set; }
    public string Bairro { get; private set; }
    public string Numero { get; private set; }
    public string Complemento { get; private set; }
    public string Cidade { get; private set; }
    public string Estado { get; private set; }
    public string Pais { get; private set; }
    public string CodigoPostal { get; private set; }

    public Endereco(TipoDeEndereco tipo, string nome, string numero, string complemento, string bairro, string cidade, string estado, string pais, string codigoPostal)
    {
        Validar(tipo, nome, numero, complemento, bairro, cidade, estado, pais, codigoPostal);

        this.Tipo = tipo;
        this.Nome = nome;
        this.Numero = numero;
        this.Complemento = complemento;
        this.Bairro = bairro;
        this.Cidade = cidade;
        this.Estado = estado;
        this.Pais = pais;
        this.CodigoPostal = codigoPostal;
    }

    private void Validar(TipoDeEndereco tipo, string nome, string numero, string complemento, string bairro, string cidade, string estado, string pais, string codigoPostal)
    {
        DomainException.ThrowIfHasSpecialCharacters(nome,"");
        DomainException.ThrowIfIsNullOrEmpty(nome,"");
        DomainException.ThrowIfExceedLenghts(nome,0,255,"");

        // ....
        // Demais validações


    }
}