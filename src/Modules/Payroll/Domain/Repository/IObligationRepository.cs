using HRP.Module.Payroll.Domain.Entity;

namespace HRP.Module.Payroll.Domain.Repository;

public interface IObligationRepository
{
    Task<Obligation> FindAsync(int id);
    Task<IEnumerable<Obligation>> FindAllUnpaidAsync(int month, int year);
    Task PersistAsync(Obligation obligation);
}
