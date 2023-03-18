
namespace Anselme.Contatos.Domain.Aggregates
{
    // Pessoa física só compro produtos até um limite de valor
    // Ela tem CPF
    // Possui apenas um contato
    public class Cliente_PessoaFisica : Cliente
    {
        public CPF Documento { get; private set; }
        public MotivoDeTrocaDeNomeParaPessoaFisica ultimaMudancaDeNome {get; private set;}

        public Cliente_PessoaFisica(Nome nomeDoCliente, Email email, List<Telefone> telefones, Telefone telefonePrincipal, List<Endereco> enderecos, Endereco enderecoPrincipal, CPF documento)
                    :base(nomeDoCliente, email, telefones, telefonePrincipal, enderecos, enderecoPrincipal)
        {
            this.Documento = documento;
        }

      
        public void AlterarNome(Nome nomeNovo, MotivoDeTrocaDeNomeParaPessoaFisica motivo)
        {
            this.NomeDoCliente = nomeNovo;
        }







    }
}