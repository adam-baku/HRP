using HRP.Module.Payroll.Shared;
using HRP.Shared.Command;

namespace HRP.Module.Payroll.Application.Command;

public struct AddObligationCommand(int employeeId, string bankAccount, decimal amount, Currency currency) : ICommand
{
    public readonly int EmployeeId => employeeId;
    public readonly string BankAccount => bankAccount;
    public readonly decimal Amount => amount;
    public readonly Currency Currency => currency;
}
