namespace HRP.Module.Payroll.Domain.Repository;

public interface IEmployeeRepository
{
    Task<bool> ExistsAsync(int employeeId);
}
