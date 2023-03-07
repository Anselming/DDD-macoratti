using System.ComponentModel.DataAnnotations;

namespace Contatos.Web.DTO
{
    public class ContatoDTO
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }
    }
}