using HRP.Module.Payroll.Shared;

namespace HRP.Module.Payroll.Application.Query.ViewModel;

public record class PaymentView
{
    public int ObligationId { get; init; }
    public string EmployeeFullName { get; init; }
    public string AmountWithCurrency { get; init; }
    public DateTime PaidAt { get; init; }
}
