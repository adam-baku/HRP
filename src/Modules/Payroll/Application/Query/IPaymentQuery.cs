using HRP.Module.Payroll.Application.Query.ViewModel;

namespace HRP.Module.Payroll.Application.Query;

public interface IPaymentQuery
{
    Task<IEnumerable<PaymentView>> GetPaymentsAsync(PaymentFilter filter);
}
