using HRP.Module.Payroll.Domain.Entity;
using HRP.Module.Payroll.Shared;
using HRP.Shared.Model;

namespace HRP.Module.Payroll.Domain.Policy;

public class HRSalaryPolicy : ISalaryPolicy
{
    private const decimal baseSalary = 1234.50m;
    public Amount CalculateSalary(EmploymentForm employmentForm) => employmentForm switch
    {
        EmploymentForm.B2B => new(baseSalary * 1.23m, Currency.PLN),
        _ => new(baseSalary, Currency.PLN)
    };
}
