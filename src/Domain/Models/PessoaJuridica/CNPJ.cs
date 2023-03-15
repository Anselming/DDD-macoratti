namespace Anselme.Contatos.Domain.Models;
public class CNPJ
{
    public int Parte1{get; private set;}
    public int Parte2{get; private set;}
    public int Parte3{get; private set;}
    public int Parte4{get; private set;}

    public CodigoCNPJ(int parte1, int parte2, int parte3, int parte4, int digitoVerificador)
    {
        Validar(parte1, parte2, parte3, parte4, digitoVerificador);
        this.Parte1 = parte1;
        this.Parte2 = parte2;
        this.Parte3 = parte3;
        this.Parte4 = parte4;

    }

    private void Validar(int parte1, int parte2, int parte3, int parte4, int digitoVerificador)
    {
        // XX.XXX.XXX/YYYY-ZZ
        // 12.345.678/9123-45

        DomainException.ThrowIfExceedLenghts(parte1, 0, 99,"A primeira parte do CNPJ não pode ser maior do que 99 (XX.123.456/7890-12)");
        DomainException.ThrowIfExceedLenghts(parte2, 0, 999,"A segunda parte do CNPJ não pode ser maior do que 999 (12.XXX.456/7890-12)");
        DomainException.ThrowIfExceedLenghts(parte3, 0, 999,"A terceira parte do CNPJ não pode ser maior do que 999 (12.489.XXX/7890-12)");
        DomainException.ThrowIfExceedLenghts(parte4, 0, 9999,"A quarta parte do CNPJ não pode ser maior do que 9999 (12.489.456/XXXX-12)");
        DomainException.ThrowIfExceedLenghts(digitoVerificador, 0, 99,"O dígito verificador não pode ser maior do que 99 (12.489.456/4387-XX)");
    }

    public string ObterCodigoDeIdentificacaoDoCliente()
    {
        return ToString();
    }
}