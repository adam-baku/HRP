namespace HRP.Module.Payroll.Domain.Exception;

public class InvalidBankAccountException : System.Exception
{
    protected InvalidBankAccountException(string? message) : base(message)
    {
    }

    public static InvalidBankAccountException Default(string bankAccount)
    {
        return new("Invalid bank account.");
    }
}
