
namespace Anselme.Contatos.Domain.Models
{
    // Ela possui tipo
    // O limite das compras varia pelo tipo
    // Possui n contatos e um principal
    public class Cliente_PessoaJuridica : Cliente
    {        
        public Nome NomeFantasia{get; private set;}
        public Nome RazaoSocial{get; private set;}

        // Possui Contatos
        
        public Cliente_PessoaJuridica()
        {

        }

        public void AlterarNome(Nome novoNomeFantasia, Nome novaRazaoSocial, MotivoDeTrocaDeNomeParaPessoaJuridica motivo)
        {

        }

    }
}