using Contatos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Infra.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contato> Contatos{get; set;}
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
