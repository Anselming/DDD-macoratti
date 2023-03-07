
using Contatos.Application.DI;

class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {    
        Inicializer.Configure(services, Configuration.GetConnectionString("DefaultConnection"));
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
    {  


    }
}