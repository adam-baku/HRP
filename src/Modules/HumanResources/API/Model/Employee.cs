namespace HRP.Module.HumanResources.API;

public class Employee
{
    public int Id { get; private set; }
    public required string Name { get; set; }
    public required string LastName { get; set; }
    public required Address Address { get; set; }
    public required Department Department { get; set; }
    public required DateTime EmployedOn { get; set; }
    public required EmploymentForm FormOfEmployment { get; set; }
    public required EmploymentOption OptionOfEmployment { get; set; }

    // private DateTime createdAt;
    // private DateTime updatedAt;
}
