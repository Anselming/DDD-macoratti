
namespace Anselme.Contatos.Domain.Models
{
    // Pessoa física só compro produtos até um limite de valor
    // Ela tem CPF
    // Possui apenas um contato
    public class Cliente_PessoaFisica : Cliente
    {
        public CPF Documento { get; private set; }

        public Cliente_PessoaFisica()
        {

        }

      
        public void AlterarNome(Nome nomeNovo, MotivoDeTrocaDeNomeParaPessoaFisica motivo)
        {

        }





    }
}