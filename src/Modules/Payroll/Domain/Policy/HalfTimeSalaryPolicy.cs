using HRP.Module.Payroll.Domain.Entity;
using HRP.Shared.Model;

namespace HRP.Module.Payroll.Domain.Policy;

public class HalfTimeSalaryPolicy(ISalaryPolicy salaryPolicy) : ISalaryPolicy
{
    public Amount CalculateSalary(EmploymentForm employmentForm)
    {
        var amount = salaryPolicy.CalculateSalary(employmentForm);

        return new(amount.Value / 2m, amount.Currency);
    }
}
