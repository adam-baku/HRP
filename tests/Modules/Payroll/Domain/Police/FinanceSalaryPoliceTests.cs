using HRP.Module.Payroll.Domain.Police;
using HRP.Module.Payroll.Shared;
using HRP.Shared.Model;

namespace HRP.Tests.Modules.Payroll.Domain;

public class FinanceSalaryPoliceTests
{
    [Theory]
    [MemberData(nameof(DataProvider))]
    public void ShouldCalculateSalaryCorrectly(EmploymentForm givenEmploymentForm, decimal expectedAmount, Currency expectedCurrency)
    {
        //given
        var police = new FinanceSalaryPolice();

        //when
        var result = police.CalculateSalary(givenEmploymentForm);

        //then
        Assert.Equal(expectedAmount, result.Value);
        Assert.Equal(expectedCurrency, result.Currency);
    }

    public static List<object[]> DataProvider =>
        new()
        {
            new object[] { EmploymentForm.B2B, 246m, Currency.USD },
            new object[] { EmploymentForm.EmploymentContract, 180m, Currency.PLN },
            new object[] { EmploymentForm.OrderContract, 210m, Currency.USD },
            new object[] { EmploymentForm.SpecificTaskContract, 220m, Currency.USD }
        };
}
