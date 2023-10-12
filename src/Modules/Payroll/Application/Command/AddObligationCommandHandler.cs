using HRP.Module.Payroll.Domain.Entity;
using HRP.Module.Payroll.Domain.Exception;
using HRP.Module.Payroll.Domain.Repository;
using HRP.Shared.Command;

namespace HRP.Module.Payroll.Application.Command;

public class AddObligationCommandHandler(IObligationRepository obligationRepository, IEmployeeRepository employeeRepository) : ICommandHandler<AddObligationCommand>
{
    /// <exception cref="EmployeeNotExistsException" />
    /// <exception cref="IncorrectAmountException" />
    /// <exception cref="InvalidBankAccountException" />
    public async Task HandleAsync(AddObligationCommand command)
    {
        if (!await employeeRepository.ExistsAsync(command.EmployeeId))
        {
            throw EmployeeNotExistsException.ForId(command.EmployeeId);
        }

        var obligation = new Obligation(
                new(command.EmployeeId, command.BankAccount),
                new(command.Amount, command.Currency)
            );

        await obligationRepository.PersistAsync(obligation);
    }
}
