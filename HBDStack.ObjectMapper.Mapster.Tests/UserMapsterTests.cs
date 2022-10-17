using AutoBogus;
using FluentAssertions;
using HBDStack.ObjectMapper.Abstraction;
using HBDStack.ObjectMapper.Mapster.Tests.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace HBDStack.ObjectMapper.Mapster.Tests;

public class UserMapsterTests:IClassFixture<MapsterMapFixture>
{
    private readonly MapsterMapFixture _fixture;

    public UserMapsterTests(MapsterMapFixture fixture) => _fixture = fixture;
    
    [Fact]
    public void CustomerGenericMap()
    {
        var mapper = _fixture.Provider.GetRequiredService<IObjectMapper>();
        var cus = AutoFaker.Generate<UserDTO>();
        var rs = mapper.Map<User>(cus);

        rs.Id.Should().Be(cus.Id).And.Subject.Should().NotBeEmpty();
        rs.Email.Should().Be(cus.Email).And.Subject.Should().NotBeNullOrEmpty();
    }
}