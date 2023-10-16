using HRP.Module.Payroll.Domain.Entity;
using HRP.Shared.Model;

namespace HRP.Module.Payroll.Domain.Police;

public interface ISalaryPolice
{
    Amount CalculateSalary(EmploymentForm employmentForm);
}
