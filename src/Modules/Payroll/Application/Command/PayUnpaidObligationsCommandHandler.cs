using HRP.Module.Payroll.Application.Command;
using HRP.Module.Payroll.Domain.Repository;
using HRP.Module.Payroll.Domain.Service;
using HRP.Shared.Command;

namespace HRP.Module.Payroll.Application;

public class PayUnpaidObligationsCommandHandler(IObligationRepository obligationRepository, IPaymentRepository paymentRepository, IBankProvider bankProvider) : ICommandHandler<PayUnpaidObligationsCommand>
{
    public async Task HandleAsync(PayUnpaidObligationsCommand command)
    {
        var unpaidObligations = await obligationRepository.FindAllUnpaidAsync(command.Month, command.Year);

        foreach (var obligationToPay in unpaidObligations)
        {
            var payment = obligationToPay.Pay();

            await bankProvider.TransferAsync(payment);

            payment.MarkAsPaid();

            try
            {
                await paymentRepository.PersistAsync(payment);
            }
            catch
            {
                await bankProvider.CancelAsync(payment);
                throw;
            }
        }
    }
}
