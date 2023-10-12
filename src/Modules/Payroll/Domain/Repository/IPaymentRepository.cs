using HRP.Module.Payroll.Domain.Entity;

namespace HRP.Module.Payroll.Domain.Repository;

public interface IPaymentRepository
{
    Task PersistAsync(Payment payment);
}
