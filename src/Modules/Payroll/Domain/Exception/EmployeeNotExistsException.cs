namespace HRP.Module.Payroll.Domain.Exception;

public class EmployeeNotExistsException : System.Exception
{
    protected EmployeeNotExistsException(string? message) : base(message)
    {
    }

    public static EmployeeNotExistsException ForId(int id)
    {
        return new($"Employee with id #{id} does not exists.");
    }
}
