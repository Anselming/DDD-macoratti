using Anselme.Contatos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Anselme.Contatos.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contato> Contatos{get; set;}
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }        
    }
}
