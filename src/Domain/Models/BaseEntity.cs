namespace Anselme.Contatos.Domain.Models
{
    public class BaseEntity
    {
        public int Id { get; private set; }

        public BaseEntity(int id)
        {
            this.Id = id;
        }

        public BaseEntity()
        {
            
        }
    }
}