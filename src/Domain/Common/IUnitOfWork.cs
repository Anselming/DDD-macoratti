namespace Anselme.Contatos.Domain.Common
{
    public interface IUnitOfWork
    {
        Task Commit();
    }

}