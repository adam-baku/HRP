using HRP.Module.Payroll.Domain.Exception;
using HRP.Module.Payroll.Shared;

namespace HRP.Module.Payroll.Domain.Entity;

public class Amount
{
    public decimal Value { get; init; }
    public Currency Currency { get; init; }

    /// <exception cref="IncorrectAmountException" />
    public Amount(decimal value, Currency currency)
    {
        if (value <= 0)
        {
            throw IncorrectAmountException.IsNegative(value);
        }

        Value = value;
        Currency = Currency;
    }
}
