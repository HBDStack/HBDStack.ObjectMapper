using System.Reflection;
using HBDStack.ObjectMapper.Abstraction;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace HBDStack.ObjectMapper.Mapster;

public static class SetupObjectMapster
{
    public static IServiceCollection AddMapsterObjectMapper(this IServiceCollection services, TypeAdapterConfig? config=null )
    {
        if (services.Any(t => t.ServiceType == typeof(IMapper))) return services;
        
        config ??= TypeAdapterConfig.GlobalSettings;
        
        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();
        
        return services.AddScoped<IObjectMapper,MapsterObjectMapper>();
    }
    
    public static IServiceCollection AddMapsterObjectMapper(this IServiceCollection services, params Assembly[] registerAssemblies)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(registerAssemblies);

        return services.AddMapsterObjectMapper(config);
    }
}