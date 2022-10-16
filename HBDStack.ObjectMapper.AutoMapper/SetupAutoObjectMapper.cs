using System.Reflection;
using AutoMapper;
using HBDStack.ObjectMapper.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HBDStack.ObjectMapper.AutoMapper;

public static class SetupAutoObjectMapper
{
    public static IServiceCollection AddAutoObjectMapper(this IServiceCollection services, Action<IMapperConfigurationExpression>? autoMapperConfig = null,params Assembly[] profileAssemblies )
    {
        autoMapperConfig ??= cf => cf.ShouldUseConstructor = f => f.IsPublic;
        
        return services
            .AddAutoMapper(autoMapperConfig, profileAssemblies)
            .AddTransient<IObjectMapper,AutoObjectMapper>();
    }
}