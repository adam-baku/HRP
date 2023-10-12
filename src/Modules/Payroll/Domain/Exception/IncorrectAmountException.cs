namespace HRP.Module.Payroll.Domain.Exception;

public class IncorrectAmountException : System.Exception
{
    protected IncorrectAmountException(string? message) : base(message)
    {
    }

    public static IncorrectAmountException IsNegative(decimal amount)
    {
        return new("Amount have to be positive, greater than 0.");
    }
}
