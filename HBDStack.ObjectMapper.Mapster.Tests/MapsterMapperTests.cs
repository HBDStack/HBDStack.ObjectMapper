using AutoBogus;
using FluentAssertions;
using HBDStack.ObjectMapper.Abstraction;
using HBDStack.ObjectMapper.Mapster.Tests.Classes;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace HBDStack.ObjectMapper.Mapster.Tests;

public class MapsterMapperTests:IClassFixture<MapsterMapFixture>
{
    private readonly MapsterMapFixture _fixture;

    public MapsterMapperTests(MapsterMapFixture fixture) => _fixture = fixture;

    [Fact]
    public void ConfigurationProvider()
    {
        var mapper = _fixture.Provider.GetRequiredService<IObjectMapper>();
        (mapper.ConfigurationProvider is TypeAdapterConfig).Should().BeTrue();
    }
    
    [Fact]
    public void CustomerGenericMap()
    {
        var mapper = _fixture.Provider.GetRequiredService<IObjectMapper>();
        var cus = AutoFaker.Generate<Customer>();

        var rs = mapper.Map<CustomerDTO>(cus);

        rs.Id.Should().Be(cus.Id).And.Subject.Value.Should().NotBe(0);
        rs.Name.Should().Be(cus.Name).And.Subject.Should().NotBeNullOrEmpty();
        rs.AddressCountry.Should().Be(cus.Address.Country).And.Subject.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public void CustomerGeneric2Map()
    {
        var mapper = _fixture.Provider.GetRequiredService<IObjectMapper>();
        var cus = AutoFaker.Generate<Customer>();

        var rs = mapper.Map<Customer, CustomerDTO>(cus);

        rs.Id.Should().Be(cus.Id).And.Subject.Value.Should().NotBe(0);
        rs.Name.Should().Be(cus.Name).And.Subject.Should().NotBeNullOrEmpty();
        rs.AddressCountry.Should().Be(cus.Address.Country).And.Subject.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public void CustomerGeneric3Map()
    {
        var mapper = _fixture.Provider.GetRequiredService<IObjectMapper>();
        var cus = AutoFaker.Generate<Customer>();
        var rs = new CustomerDTO();
        mapper.Map(cus,rs);

        rs.Id.Should().Be(cus.Id).And.Subject.Value.Should().NotBe(0);
        rs.Name.Should().Be(cus.Name).And.Subject.Should().NotBeNullOrEmpty();
        rs.AddressCountry.Should().Be(cus.Address.Country).And.Subject.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public void CustomerTypeMap()
    {
        var mapper = _fixture.Provider.GetRequiredService<IObjectMapper>();
        var cus = AutoFaker.Generate<Customer>();

        var rs =(CustomerDTO) mapper.Map(cus,typeof(Customer),typeof(CustomerDTO));

        rs.Id.Should().Be(cus.Id).And.Subject.Value.Should().NotBe(0);
        rs.Name.Should().Be(cus.Name).And.Subject.Should().NotBeNullOrEmpty();
        rs.AddressCountry.Should().Be(cus.Address.Country).And.Subject.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public void CustomerType2Map()
    {
        var mapper = _fixture.Provider.GetRequiredService<IObjectMapper>();
        var cus = AutoFaker.Generate<Customer>();
        var rs = new CustomerDTO();
         mapper.Map(cus,rs,typeof(Customer),typeof(CustomerDTO));

        rs.Id.Should().Be(cus.Id).And.Subject.Value.Should().NotBe(0);
        rs.Name.Should().Be(cus.Name).And.Subject.Should().NotBeNullOrEmpty();
        rs.AddressCountry.Should().Be(cus.Address.Country).And.Subject.Should().NotBeNullOrEmpty();
    }
}