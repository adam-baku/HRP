using HRP.Module.Payroll.Domain.Entity;

namespace HRP.Module.Payroll.Domain.Service;

public interface IBankProvider
{
    Task Transfer(Payment payment);
    Task Cancel(Payment payment);
}
