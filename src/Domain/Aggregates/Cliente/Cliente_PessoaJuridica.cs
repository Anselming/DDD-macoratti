
namespace Anselme.Contatos.Domain.Aggregates
{
    public class Cliente_PessoaJuridica : Cliente
    {        
        public Nome NomeFantasia{get; private set;}
        public Nome RazaoSocial{get; private set;}
        public CNPJ Documento { get; private set; }    
        public MotivoDeTrocaDeNomeParaPessoaJuridica ultimaMudancaDeNome {get; private set;} 
        public TipoDePessoaJuridica Tipo{get; private set;}   

       
        public Cliente_PessoaJuridica(Nome nomeFantasia, Nome razaoSocial, Email email, List<Telefone> telefones, Telefone telefonePrincipal, List<Endereco> enderecos, Endereco enderecoPrincipal, CNPJ documento, TipoDePessoaJuridica tipo)
                    :base(nomeFantasia, email, telefones, telefonePrincipal, enderecos, enderecoPrincipal)
        {
            this.Documento = documento;
            this.NomeDoCliente = nomeFantasia;
            this.NomeFantasia = nomeFantasia;
            this.RazaoSocial = razaoSocial;
            this.Tipo = tipo;
        }

        public void AlterarNome(Nome novoNomeFantasia, Nome novaRazaoSocial, MotivoDeTrocaDeNomeParaPessoaJuridica motivo)
        {
            this.NomeDoCliente = novoNomeFantasia;
            this.NomeFantasia = NomeFantasia;
            this.RazaoSocial = novaRazaoSocial;
            this.ultimaMudancaDeNome = motivo;
        }

    }
}