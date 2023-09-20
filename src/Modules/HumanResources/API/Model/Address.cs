namespace HRP.Module.HumanResources.API;

public class Address
{
    public int Id { get; private set; }
    public required string Country { get; set; }
    public required string City { get; set; }
    public required string Street { get; set; }
}
