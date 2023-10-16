using HRP.Module.Payroll.Domain.Entity;

namespace HRP.Module.Payroll.Domain.Service;

public interface IBankProvider
{
    Task TransferAsync(Payment payment);
    Task CancelAsync(Payment payment);
}
