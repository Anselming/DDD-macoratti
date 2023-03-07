using Contatos.Domain.Interfaces;
using Contatos.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Contatos.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatosController: ControllerBase
    {
        private readonly ContatoService _contatoService;
        private readonly IRepository<Contato> _contatoRepository;

        public ContatosController(ContatoService contatoService, IRepository<Contato> contatoRepository)
        {
            _contatoService = contatoService;
            _contatoRepository = contatoRepository;
        }

        [HttpGet(Name = "Contatos")]
        public IEnumerable<Contato> GetContatos()
        {
            return _contatoRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Contato> GetContatos(int id)
        {
            var contato = _contatoRepository.GetById(id);

            if(contato == null) 
                return NotFound("Não encontrado!");
            return contato;
        }
    }
}