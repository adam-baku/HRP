using HRP.Module.Payroll.Domain.Entity;
using HRP.Shared.Model;

namespace HRP.Module.Payroll.Domain.Policy;

public interface ISalaryPolicy
{
    Amount CalculateSalary(EmploymentForm employmentForm);
}
