using HRP.Module.Payroll.Domain.Entity;
using HRP.Module.Payroll.Shared;
using HRP.Shared.Model;

namespace HRP.Module.Payroll.Domain.Policy;

public class SalesSalaryPolicy : ISalaryPolicy
{
    public Amount CalculateSalary(EmploymentForm employmentForm) => employmentForm switch
    {
        EmploymentForm.B2B => new(1500m * 1.23m, Currency.PLN),
        EmploymentForm.EmploymentContract => new(1200m, Currency.PLN),
        EmploymentForm.OrderContract => new(1500m, Currency.PLN),
        EmploymentForm.SpecificTaskContract => new(1600m, Currency.PLN)
    };
}
