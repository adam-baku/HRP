using HRP.Module.Payroll.Application.Command;
using HRP.Module.Payroll.Domain.Entity;
using HRP.Module.Payroll.Domain.Exception;
using HRP.Module.Payroll.Domain.Repository;
using HRP.Module.Payroll.Shared;

namespace HRP.Tests.Modules.Payroll.Application;

public class AddObligationCommandHandlerTests : IDisposable
{
    private readonly Mock<IObligationRepository> obligationRepositoryMock;
    private readonly Mock<IEmployeeRepository> employeeRepositoryMock;

    //setup
    public AddObligationCommandHandlerTests()
    {
        obligationRepositoryMock = new Mock<IObligationRepository>();
        employeeRepositoryMock = new Mock<IEmployeeRepository>();
    }

    [Fact]
    public async Task WhenEmployeeNotExists_WillThrowException()
    {
        //given
        var employeeId = 1000;
        var amount = 100m; //amount is not relevant
        var bankAccount = "PL82109024027123717529873262"; //bankAccount is not relevant
        var currency = Currency.PLN; //currency is not relevant

        var command = new AddObligationCommand(employeeId, bankAccount, amount, currency);

        employeeRepositoryMock.Setup(mock => mock.ExistsAsync(employeeId))
            .ReturnsAsync(false);

        //when
        var handler = new AddObligationCommandHandler(obligationRepositoryMock.Object, employeeRepositoryMock.Object);
        var func = () => handler.HandleAsync(command);

        //then
        await Assert.ThrowsAsync<EmployeeNotExistsException>(func);
        obligationRepositoryMock.Verify(mock => mock.PersistAsync(It.IsAny<Obligation>()), Times.Never);
    }

    [Fact]
    public async Task ShouldCreateNewObligation()
    {
        //given
        var employeeId = 1000;
        var amount = 100m;
        var bankAccount = "PL82109024027123717529873262";
        var currency = Currency.PLN;

        var command = new AddObligationCommand(employeeId, bankAccount, amount, currency);

        employeeRepositoryMock.Setup(mock => mock.ExistsAsync(employeeId))
            .ReturnsAsync(true);

        //when
        var handler = new AddObligationCommandHandler(obligationRepositoryMock.Object, employeeRepositoryMock.Object);
        await handler.HandleAsync(command);

        //then
        obligationRepositoryMock.Verify(mock =>
            mock.PersistAsync(It.Is<Obligation>(obligation =>
                obligation.Employee.Id == employeeId
                && obligation.Employee.BankAccount == bankAccount
                && obligation.Amount.Value == amount
                && obligation.Amount.Currency == currency
                && obligation.IsActive == true
                && obligation.DeactivatedAt == null
            )), Times.Once);
    }

    //teardown
    public void Dispose()
    {
        // throw new NotImplementedException();
    }
}
