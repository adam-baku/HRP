using HRP.Module.Payroll.Domain.Entity;
using HRP.Module.Payroll.Shared;
using HRP.Shared.Model;

namespace HRP.Module.Payroll.Domain.Police;

public class FinanceSalaryPolice : ISalaryPolice
{
    public Amount CalculateSalary(EmploymentForm employmentForm) => employmentForm switch
    {
        EmploymentForm.B2B => new(200m * 1.23m, Currency.USD),
        EmploymentForm.EmploymentContract => new(180m, Currency.PLN),
        EmploymentForm.OrderContract => new(210m, Currency.USD),
        EmploymentForm.SpecificTaskContract => new(220m, Currency.USD)
    };
}
