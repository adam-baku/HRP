using HRP.Shared.Model;

namespace HRP.Module.HumanResources.API.Model;

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

    public void Update(Employee employee)
    {
        Name = employee.Name;
        LastName = employee.LastName;
        Department = employee.Department;
        EmployedOn = employee.EmployedOn;
        FormOfEmployment = employee.FormOfEmployment;
        OptionOfEmployment = employee.OptionOfEmployment;

        Address.Country = employee.Address.Country;
        Address.City = employee.Address.City;
        Address.Street = employee.Address.Street;
    }
}
