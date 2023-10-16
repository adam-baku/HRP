using HRP.Module.Payroll.Domain.Entity;
using HRP.Module.Payroll.Domain.Police;
using HRP.Shared.Model;

namespace HRP.Module.Payroll.Domain.Service;

public class SalaryService
{
    public Amount CalculateSalaryFor(Department department, EmploymentOption employmentOption, EmploymentForm employmentForm)
    {
        ISalaryPolice salaryPolice = department switch
        {
            Department.HR => new HRSalaryPolice(),
            Department.IT => new ITSalaryPolice(),
            Department.Finance => new FinanceSalaryPolice(),
            Department.Sales => new SalesSalaryPolice()
        };

        if (employmentOption is EmploymentOption.HalfTime)
        {
            salaryPolice = new HalfTimeSalaryPolice(salaryPolice);
        }

        return salaryPolice.CalculateSalary(employmentForm);
    }
}
