using HRP.Module.HumanResources.API.Controllers;
using HRP.Module.HumanResources.API.Event;
using HRP.Module.Payroll.Application.Command;
using HRP.Module.Payroll.Domain.Service;
using HRP.Shared.Command;
using HRP.Shared.Event;

namespace HRP.Module.Integrator.Event;

public class NewEmployeeAddedHandler : IEventHandler<NewEmployeeAdded>
{
    private readonly ICommandHandler<AddObligationCommand> addObligationCommandHandler;
    private readonly EmployeeController employeeController;
    private readonly SalaryService salaryService;

    public NewEmployeeAddedHandler(ICommandHandler<AddObligationCommand> addObligationCommandHandler, EmployeeController employeeController, SalaryService salaryService)
    {
        this.addObligationCommandHandler = addObligationCommandHandler;
        this.employeeController = employeeController;
        this.salaryService = salaryService;
    }

    public async Task HandleAsync(NewEmployeeAdded @event)
    {
        var employee = (await employeeController.GetByIdAsync(@event.Id)).Value;

        var salary = salaryService.CalculateSalaryFor(employee!.Department, employee!.OptionOfEmployment, employee!.FormOfEmployment);

        var command = new AddObligationCommand(employee!.Id, "", salary.Value, salary.Currency);

        await addObligationCommandHandler.HandleAsync(command);
    }
}
