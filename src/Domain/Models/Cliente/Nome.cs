using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Models;
public class Nome
{
    public string PrimeiroNome { get; private set; }
    public string NomeDoMeio { get; private set; }
    public string UltimoNome { get; private set; }
    public Titulacao? Titulo { get; private set; }
    public string? Pronome { get; private set; }
    public string? Apelido { get; private set; }
    public string? ComoPrefereSerChamado { get; private set; }

    public Nome(string primeiroNome, string nomeDoMeio, string ultimoNome, Titulacao? titulo, string? pronome, string? apelido, string? comoPrefereSerChamado)
    {
        Validar(primeiroNome, nomeDoMeio, ultimoNome, titulo, pronome, apelido, comoPrefereSerChamado);
        this.PrimeiroNome = primeiroNome;
        this.NomeDoMeio = nomeDoMeio;
        this.UltimoNome = ultimoNome;
        this.Titulo = titulo;
        this.Pronome = pronome;
        this.Apelido = apelido;
        this.ComoPrefereSerChamado = comoPrefereSerChamado;

    }

    public string ObterNomeCompleto() => $"{PrimeiroNome} {NomeDoMeio} {UltimoNome}";
    public string ObterNomeComTitulacao() => $"{Titulo} {PrimeiroNome} {NomeDoMeio} {UltimoNome}";
    public string ObterNomeComPronome() => $"({Pronome}) {PrimeiroNome} {NomeDoMeio} {UltimoNome}";
    

    private void Validar(string primeiroNome, string nomeDoMeio, string ultimoNome, Titulacao? titulo, string? pronome, string? apelido, string? comoPrefereSerChamado)
    {
        // Primeiro Nome
        DomainException.ThrowIfIsNullOrEmpty(primeiroNome, "Primeiro nome não pode ser nulo");
        DomainException.ThrowIfExceedMaxLength(primeiroNome, 30, "Primeiro nome não pode ser maior do que 30 caracteres");
        DomainException.ThrowIfHasSpecialCharacters(primeiroNome, "Primeiro nome não pode ter caracteres especiais");

        // Nome do Meio
        DomainException.ThrowIfIsNullOrEmpty(nomeDoMeio, "Nome do meio não pode ser nulo");
        DomainException.ThrowIfExceedMaxLength(nomeDoMeio, 30, "Nome do meio não pode ser maior do que 30 caracteres");
        DomainException.ThrowIfHasSpecialCharacters(nomeDoMeio, "Nome do meio não pode ter caracteres especiais");

        // Último nome
        DomainException.ThrowIfIsNullOrEmpty(ultimoNome, "Último nome não pode ser nulo");
        DomainException.ThrowIfExceedMaxLength(ultimoNome, 30, "Último nome não pode ser maior do que 30 caracteres");
        DomainException.ThrowIfHasSpecialCharacters(ultimoNome, "Ultimo nome não pode ter caracteres especiais");

        // Titulo
        // Não há validação específica

        // Pronome
        if (pronome != null)
        {
            DomainException.ThrowIfExceedMaxLength(pronome, 30, "Pronome não pode ser maior do que 30 caracteres");
            DomainException.ThrowIfHasSpecialCharacters(pronome, "");
        }

        // Apelido
        if (apelido != null)
        {
            DomainException.ThrowIfExceedMaxLength(apelido, 255, "Apelido não pode ser maior do que 30 caracteres");
        }

        // Como Prefere ser chamado
        if (comoPrefereSerChamado != null)
        {
            DomainException.ThrowIfExceedMaxLength(comoPrefereSerChamado, 255, "'Como prefere ser chamado' não pode ser maior do que 30 caracteres");
        }

    }

}