namespace HRP.Module.Payroll.Domain.Entity;

public class Payment(string bankAccount, Amount amount)
{
    public string BankAccount { get; init; } = bankAccount;
    public Amount Amount { get; init; } = amount;
    public PaymentStatus Status { get; private set; } = PaymentStatus.New;
    public DateTime? PaidAt { get; private set; }

    public void MarkAsPaid()
    {
        Status = PaymentStatus.Paid;
        PaidAt = DateTime.UtcNow;
    }
}
