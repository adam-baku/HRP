using HRP.Module.Payroll.Domain.Service;
using HRP.Module.Payroll.Shared;
using HRP.Shared.Model;

namespace HRP.Tests.Modules.Payroll.Domain;

public class SalaryServiceTests
{
    [Fact]
    public void ShouldCalculateFullTimeB2BSalaryForHR()
    {
        //given
        var department = Department.HR;
        var employmentOption = EmploymentOption.FullTime;
        var employmentForm = EmploymentForm.B2B;

        //when
        var service = new SalaryService();
        var result = service.CalculateSalaryFor(department, employmentOption, employmentForm);

        //then
        Assert.Equal(1518.435m, result.Value);
        Assert.Equal(Currency.PLN, result.Currency);
    }

    [Fact]
    public void ShouldCalculateHalfTimeB2BSalaryForHR()
    {
        //given
        var department = Department.HR;
        var employmentOption = EmploymentOption.HalfTime;
        var employmentForm = EmploymentForm.B2B;

        //when
        var service = new SalaryService();
        var result = service.CalculateSalaryFor(department, employmentOption, employmentForm);

        //then
        Assert.Equal(759.2175m, result.Value);
        Assert.Equal(Currency.PLN, result.Currency);
    }
}
