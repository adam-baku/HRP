using HRP.Module.Payroll.Domain.Entity;
using HRP.Module.Payroll.Shared;
using HRP.Shared.Model;

namespace HRP.Module.Payroll.Domain.Policy;

public class ITSalaryPolicy : ISalaryPolicy
{
    private const decimal baseSalary = 400m;

    public Amount CalculateSalary(EmploymentForm employmentForm) => employmentForm switch
    {
        EmploymentForm.B2B => new(baseSalary * 1.23m, Currency.EUR),
        _ => new(baseSalary, Currency.EUR)
    };
}
