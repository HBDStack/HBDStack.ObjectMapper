using Microsoft.Extensions.DependencyInjection;

namespace HBDStack.ObjectMapper.AutoMapper.Tests;

public class AutoMapFixture:IDisposable
{
    public IServiceProvider Provider { get; }
    
    public AutoMapFixture()
    {
        Provider = new ServiceCollection()
            .AddAutoObjectMapper(profileAssemblies: typeof(AutoMapFixture).Assembly)
            .BuildServiceProvider();
    }

    public void Dispose() => ((ServiceProvider)Provider)?.Dispose();
}