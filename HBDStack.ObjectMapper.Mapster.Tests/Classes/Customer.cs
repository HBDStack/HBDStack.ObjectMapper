using Mapster;

namespace HBDStack.ObjectMapper.Mapster.Tests.Classes;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Address Address { get; set; }
}

public class CustomerDTO:BaseDto<CustomerDTO,Customer>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AddressCountry { get; set; }
    
    protected override void Config()
    {
        ConfigDto();
    }
}