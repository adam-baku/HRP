using HRP.Module.Payroll.Domain.Entity;
using HRP.Module.Payroll.Domain.Policy;
using HRP.Shared.Model;

namespace HRP.Module.Payroll.Domain.Service;

public class SalaryService
{
    public Amount CalculateSalaryFor(Department department, EmploymentOption employmentOption, EmploymentForm employmentForm)
    {
        ISalaryPolicy salaryPolicy = department switch
        {
            Department.HR => new HRSalaryPolicy(),
            Department.IT => new ITSalaryPolicy(),
            Department.Finance => new FinanceSalaryPolicy(),
            Department.Sales => new SalesSalaryPolicy()
        };

        if (employmentOption is EmploymentOption.HalfTime)
        {
            salaryPolicy = new HalfTimeSalaryPolicy(salaryPolicy);
        }

        return salaryPolicy.CalculateSalary(employmentForm);
    }
}
