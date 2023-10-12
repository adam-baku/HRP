using HRP.Module.Payroll.Domain.Entity;

namespace HRP.Module.Payroll.Domain.Repository;

public interface IObligationRepository
{
    Task<Obligation> FindAsync(int id);
    Task PersistAsync(Obligation obligation);
}
