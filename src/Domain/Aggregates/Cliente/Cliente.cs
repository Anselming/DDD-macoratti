
using Anselme.Contatos.Domain.Common;

namespace Anselme.Contatos.Domain.Aggregates
{
    public abstract class Cliente : BaseEntity, IAggregateRoot
    {
        public Nome NomeDoCliente { get; protected set; }
        public Email Email { get; private set; }
        public List<Telefone> Telefones { get; private set; }
        public Telefone TelefonePrincipal { get; private set; }
        public List<Endereco> Enderecos { get; private set; }
        public Endereco EnderecoPrincipal { get; private set; }

        public Cliente(Nome nomeDoCliente, Email email, List<Telefone> telefones, Telefone telefonePrincipal, List<Endereco> enderecos, Endereco enderecoPrincipal)
        {
            Validar(nomeDoCliente, email, telefones, telefonePrincipal, enderecos);
            this.NomeDoCliente = nomeDoCliente;
            this.Email = email;
            this.Telefones = telefones;
            this.TelefonePrincipal = telefonePrincipal;
            this.Enderecos = enderecos;
            this.EnderecoPrincipal = enderecoPrincipal;
        }

        private void Validar(Nome nomeDoCliente, Email email, List<Telefone> telefones, Telefone telefonePrincipal, List<Endereco> enderecos)
        {
            // Telefones
            DomainException.ThrowIfCountsZero(telefones, "Não há nenhum telefone da lista");
            DomainException.ThrowIfNotContains(telefones, telefonePrincipal, "O telefone indicado como principal não está condido da lista");

            // Endereços
            DomainException.ThrowIfCountsZero(enderecos, "Não há nenhum endereco da lista");
            DomainException.ThrowIfNotContains(enderecos, EnderecoPrincipal, "O endereco indicado como principal não está condido da lista");
        }

        public void SubstituirEmail(Email email)
        {

            this.Email = email;
        }


        public void AdicionarNovoTelefone(Telefone telefone)
        {
            Telefones.Add(telefone);
        }

        public void DesativarTelefoneCadastrado(Telefone telefone)
        {
            Telefones.Remove(telefone);
        }

        public void RedefinirTelefonePrincipal(Telefone telefonePrincipal)
        {
            TelefonePrincipal = telefonePrincipal;
        }

        public void AdicionarNovoEndereco(Endereco endereco)
        {
            Enderecos.Add(endereco);
        }

        public void DesativarEnderecoCadastrado(Endereco endereco)
        {
            Enderecos.Remove(endereco);
        }

        public void RedefinirEnderecoPadraoParaEntrega(Endereco endereco)
        {
            EnderecoPrincipal = endereco;
        }

    }
}