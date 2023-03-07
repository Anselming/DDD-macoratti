namespace Anselme.Contatos.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
    }

}