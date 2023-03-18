namespace Anselme.Contatos.Domain.Aggregates
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