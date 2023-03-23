using Anselme.Contatos.Infrastructure.DbEntity;
using Microsoft.EntityFrameworkCore;

namespace Anselme.Contatos.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ComprovanteDeCompra> ComprovanteDeCompra { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<ItemDeCompra> ItemDeCompra { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
