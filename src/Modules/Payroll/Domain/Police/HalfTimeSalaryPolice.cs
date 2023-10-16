using HRP.Module.Payroll.Domain.Entity;
using HRP.Shared.Model;

namespace HRP.Module.Payroll.Domain.Police;

public class HalfTimeSalaryPolice(ISalaryPolice salaryPolice) : ISalaryPolice
{
    public Amount CalculateSalary(EmploymentForm employmentForm)
    {
        var amount = salaryPolice.CalculateSalary(employmentForm);

        return new(amount.Value / 2m, amount.Currency);
    }
}
