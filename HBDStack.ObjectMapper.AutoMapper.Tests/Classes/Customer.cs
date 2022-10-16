using AutoMapper;

namespace HBDStack.ObjectMapper.AutoMapper.Tests.Classes;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Address Address { get; set; }
}

[AutoMap(typeof(Customer),ReverseMap = true)]
public class CustomerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AddressCountry { get; set; }
}