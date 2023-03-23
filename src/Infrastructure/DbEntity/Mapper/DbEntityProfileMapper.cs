using AutoMapper;

using AGGREGATE = Anselme.Contatos.Domain.Aggregates;
using DATABASE = Anselme.Contatos.Infrastructure.DbEntity;


namespace Anselme.Contatos.Infrastructure.DbEntity;
// This is the approach starting with version 5
public class DbEntityProfileMapper
{
    public IMapper Mapper
    {
        get { return GetMap().CreateMapper(); }
    }


    public MapperConfiguration GetMap()
    {
        MapperConfiguration config = new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<AGGREGATE.Cliente, DATABASE.Cliente>()
                    // Nome
                    .ForMember(member => member.PrimeiroNome, map => map.MapFrom(source => source.NomeDoCliente.PrimeiroNome))
                    .ForMember(member => member.NomeDoMeio, map => map.MapFrom(source => source.NomeDoCliente.NomeDoMeio))                    
                    .ForMember(member => member.UltimoNome, map => map.MapFrom(source => source.NomeDoCliente.UltimoNome))                    
                    .ForMember(member => member.Titulo, map => map.MapFrom(source => source.NomeDoCliente.Titulo))                    
                    .ForMember(member => member.Pronome, map => map.MapFrom(source => source.NomeDoCliente.Pronome))                    
                    .ForMember(member => member.Apelido, map => map.MapFrom(source => source.NomeDoCliente.Apelido))
                    .ForMember(member => member.ComoPrefereSerChamado, map => map.MapFrom(source => source.NomeDoCliente.ComoPrefereSerChamado))
                    // Email
                    .ForMember(member => member.Email, map => map.MapFrom(source => source.Email.ToString()));
                    // Telefones
                    //.ForMember(member => member.Telefones, map => map.MapFrom(source => source.Telefones))
                    // Telefone
                    //.ForMember(member => member.TelefonePrincipal, map => map.MapFrom(source => source.TelefonePrincipal))
                    // Endereços
                    //.ForMember(member => member.Enderecos, map => map.MapFrom(source => source.Enderecos))
                    // Endereço
                    //.ForMember(member => member.EnderecoPrincipal, map => map.MapFrom(source => source.EnderecoPrincipal));
                                        
               cfg.CreateMap<AGGREGATE.ComprovanteDeCompra, DATABASE.ComprovanteDeCompra>();
               cfg.CreateMap<AGGREGATE.Endereco, DATABASE.Endereco>();
               cfg.CreateMap<AGGREGATE.ItemDeCompra, DATABASE.ItemDeCompra>();
               cfg.CreateMap<AGGREGATE.Produto, DATABASE.Produto>();
               cfg.CreateMap<AGGREGATE.Telefone, DATABASE.Telefone>();

           });

        return config;
    }

   
}

