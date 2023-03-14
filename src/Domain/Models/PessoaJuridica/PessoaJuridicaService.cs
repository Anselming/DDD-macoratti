using Anselme.Contatos.Domain.Interfaces;

namespace Anselme.Contatos.Domain.Models
{
    public class PessoaJuridicaService
    {
        private readonly IRepository<Contato> _contatoRepository;

        public PessoaJuridicaService(IRepository<Contato> contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public void Save(int id, string nome, string email)
        {
            var contato = _contatoRepository.GetById(id);

            if(contato == null)
            {
                contato = new Contato(nome, email);
                _contatoRepository.CreateNew(contato);
            }
            else
            {
                contato.Update(nome, email);
            }
        }
    }
}