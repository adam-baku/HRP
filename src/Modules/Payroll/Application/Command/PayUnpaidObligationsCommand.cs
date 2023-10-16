using HRP.Shared.Command;

namespace HRP.Module.Payroll.Application.Command;

public struct PayUnpaidObligationsCommand(DateOnly date) : ICommand
{
    public int Month => date.Month;
    public int Year => date.Year;
}
