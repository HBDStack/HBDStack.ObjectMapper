using System.Reflection;
using AutoMapper;
using HBDStack.ObjectMapper.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace HBDStack.ObjectMapper.AutoMapper;

public static class SetupAutoObjectMapper
{
    public static IServiceCollection AddAutoObjectMapper(this IServiceCollection services, Action<IMapperConfigurationExpression>? autoMapperConfig = null,params Assembly[] profileAssemblies )
    {
        if (services.All(t => t.ServiceType != typeof(IMapper)))
        {
            autoMapperConfig ??= cf => cf.ShouldUseConstructor = f => f.IsPublic;
            services
                .AddAutoMapper(autoMapperConfig, profileAssemblies);
        }

        return services
            .AddTransient<IObjectMapper,AutoObjectMapper>();
    }
}