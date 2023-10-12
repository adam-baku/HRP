using HRP.Module.Payroll.Shared;
using HRP.Shared.Command;

namespace HRP.Module.Payroll.Application.Command;

public class AddObligationCommand(int employeeId, string bankAccount, decimal amount, Currency currency) : ICommand
{
    public int EmployeeId => employeeId;
    public string BankAccount => bankAccount;
    public decimal Amount => amount;
    public Currency Currency => currency;
}
