namespace HRP.Module.Payroll.Domain.Entity;

public class Employee(int id, string bankAccount)
{
    public int Id { get; init; } = id;
    public string BankAccount { get; private set; } = bankAccount;

    public void ChangeBankAccount(string newBankAccount)
    {
        BankAccount = newBankAccount;
    }
}
