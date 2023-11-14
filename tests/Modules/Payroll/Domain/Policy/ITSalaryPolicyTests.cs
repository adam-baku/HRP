using HRP.Module.Payroll.Domain.policy;
using HRP.Module.Payroll.Shared;
using HRP.Shared.Model;

namespace HRP.Tests.Modules.Payroll.Domain;

public class ITSalarypolicyTests
{
    [Theory]
    [MemberData(nameof(DataProvider))]
    public void ShouldCalculateSalaryCorrectly(EmploymentForm givenEmploymentForm, decimal expectedAmount, Currency expectedCurrency)
    {
        //given
        var policypolicy = new ITSalarypolicy();

        //when
        var result = policypolicy.CalculateSalary(givenEmploymentForm);

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
