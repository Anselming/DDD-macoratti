using Anselme.Contatos.Domain.Interfaces;

namespace Anselme.Contatos.Domain.Models
{
    public class ProdutoService
    {
        private readonly IRepository<Produto> _produtoRepository;

        public ProdutoService(IRepository<Produto> produtoRepository)
        {
            this._produtoRepository = produtoRepository;
        }

        public void RegistrarNovoProduto(Produto produto)
        {
            _produtoRepository.CreateNew(produto);
        }        
    }
}