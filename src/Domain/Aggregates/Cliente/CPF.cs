using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Aggregates;
public class CPF
{
    public int Parte1{get; private set;}
    public int Parte2{get; private set;}
    public int Parte3{get; private set;}

    public CPF(int parte1, int parte2, int parte3, int digitoVerificador)
    {
        Validar(parte1, parte2, parte3, digitoVerificador);
        this.Parte1 = parte1;
        this.Parte2 = parte2;
        this.Parte3 = parte3;

    }

    private void Validar(int parte1, int parte2, int parte3, int digitoVerificador)
    {
        // XXX.XXX.XXX-ZZ
        // 123.345.678-45

        DomainException.ThrowIfExceedLenghts(parte1, 0, 999,"A primeira parte do CPF não pode ser maior do que 99 (XXX.123.456-12)");
        DomainException.ThrowIfExceedLenghts(parte2, 0, 999,"A segunda parte do CPF não pode ser maior do que 999 (123.XXX.456-12)");
        DomainException.ThrowIfExceedLenghts(parte3, 0, 999,"A terceira parte do CPF não pode ser maior do que 999 (123.489.XXX-12)");
        DomainException.ThrowIfExceedLenghts(digitoVerificador, 0, 99,"O dígito verificador não pode ser maior do que 99 (123.489.456-XX)");
    }

    public string ObterCodigoDeIdentificacaoDoCliente()
    {
        return ToString();
    }
}