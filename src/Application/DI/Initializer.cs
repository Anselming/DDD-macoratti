using Anselme.Contatos.Domain.Interfaces;
using Anselme.Contatos.Domain.Models;
using Anselme.Contatos.Infrastructure.Contexts;
using Anselme.Contatos.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contatos.Application.DI;

public class Inicializer
{
    public static void Configure(IServiceCollection services, string connection)
    {
        services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connection));

        services.AddScoped(typeof(IRepository<Contato>), typeof(ContatoRepository));
        services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.AddScoped(typeof(ContatoService));
        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

    }
}