using HRP.Module.Payroll.Domain.Police;
using HRP.Module.Payroll.Shared;
using HRP.Shared.Model;

namespace HRP.Tests.Modules.Payroll.Domain;

public class ITSalaryPoliceTests
{
    [Theory]
    [MemberData(nameof(DataProvider))]
    public void ShouldCalculateSalaryCorrectly(EmploymentForm givenEmploymentForm, decimal expectedAmount, Currency expectedCurrency)
    {
        //given
        var police = new ITSalaryPolice();

        //when
        var result = police.CalculateSalary(givenEmploymentForm);

        //then
        Assert.Equal(expectedAmount, result.Value);
        Assert.Equal(expectedCurrency, result.Currency);
    }

    public static List<object[]> DataProvider =>
        new()
        {
            new object[] { EmploymentForm.B2B, 492m, Currency.EUR },
            new object[] { EmploymentForm.EmploymentContract, 400m, Currency.EUR },
            new object[] { EmploymentForm.OrderContract, 400m, Currency.EUR },
            new object[] { EmploymentForm.SpecificTaskContract, 400m, Currency.EUR }
        };
}
