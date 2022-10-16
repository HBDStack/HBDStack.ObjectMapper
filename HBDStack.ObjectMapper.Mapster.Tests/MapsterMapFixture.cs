using Microsoft.Extensions.DependencyInjection;

namespace HBDStack.ObjectMapper.Mapster.Tests;

public class MapsterMapFixture:IDisposable
{
    public IServiceProvider Provider { get; }
    
    public MapsterMapFixture()
    {
        Provider = new ServiceCollection()
            .AddMapsterObjectMapper(registerAssemblies: typeof(MapsterMapFixture).Assembly)
            .BuildServiceProvider();
    }

    public void Dispose() => ((ServiceProvider)Provider)?.Dispose();
}