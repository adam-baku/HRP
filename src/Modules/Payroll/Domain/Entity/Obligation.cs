namespace HRP.Module.Payroll.Domain.Entity;

public class Obligation(Employee employee, Amount amount)
{
    public int Id { get; init; }
    public Employee Employee { get; init; } = employee;
    public Amount Amount { get; init; } = amount;
    public bool IsActive { get; private set; } = true;
    public DateTime? DeactivatedAt { get; private set; }

    private List<Payment> payments = new();

    public void ChangeBankAccount(string newBankAccount)
    {
        Employee.ChangeBankAccount(newBankAccount);
    }

    public void Deactivate()
    {
        IsActive = false;
        DeactivatedAt = DateTime.UtcNow;
    }

    public Payment Pay()
    {
        Payment payment = new(Employee.BankAccount, Amount);
        payments.Add(payment);

        return payment;
    }
}
