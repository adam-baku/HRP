using HRP.Module.Payroll.Domain.Entity;
using HRP.Module.Payroll.Shared;

namespace HRP.Tests.Modules.Payroll.Domain.Entity;

public class ObligationTests
{
    [Fact]
    public void ShouldDeactivateObligation()
    {
        //given
        var employeeId = 1000;
        var bankAccount = "PL64109024025412277713657952";

        var amount = 100m;
        var currency = Currency.PLN;

        var obligation = new Obligation(new(employeeId, bankAccount), new(amount, currency));

        //when
        obligation.Deactivate();

        //then
        Assert.False(obligation.IsActive);
        Assert.NotNull(obligation.DeactivatedAt);
    }

    [Fact]
    public void WhenPayObligation_WillReturnNewPayment()
    {
        //given
        var employeeId = 1000;
        var bankAccount = "PL64109024025412277713657952";

        var amount = 100m;
        var currency = Currency.PLN;

        var obligation = new Obligation(new(employeeId, bankAccount), new(amount, currency));

        //when
        var payment = obligation.Pay();

        //then
        Assert.Equal(PaymentStatus.New, payment.Status);
        Assert.Null(payment.PaidAt);

        Assert.Equal("PL64109024025412277713657952", payment.BankAccount);
        Assert.Equal(100m, payment.Amount.Value);
        Assert.Equal(Currency.PLN, payment.Amount.Currency);
    }
}
