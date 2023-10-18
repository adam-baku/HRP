using HRP.Module.Payroll.Domain.Entity;
using HRP.Module.Payroll.Domain.Exception;
using HRP.Module.Payroll.Shared;

namespace HRP.Tests.Modules.Payroll.Domain.Entity;

public class AmountTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    public void CreateWithNegativeValue_WillThrowException(int value)
    {
        //given
        var currency = Currency.PLN; //currencly is not relevant

        //when
        Amount action() => new(value, currency);

        //then
        Assert.Throws<IncorrectAmountException>(action);
    }

    [Fact]
    public void CreateWithPositiveValue_WillCreateInstanceCorrectly()
    {
        //given
        var value = 100m;
        var currency = Currency.PLN; //currencly is not relevant

        //when
        Amount amount = new(value, currency);

        //then
        Assert.Equal(100m, amount.Value);
        Assert.Equal(Currency.PLN, amount.Currency);
    }
}
