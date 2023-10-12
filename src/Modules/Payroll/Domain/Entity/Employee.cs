using System.Text.RegularExpressions;
using HRP.Module.Payroll.Domain.Exception;

namespace HRP.Module.Payroll.Domain.Entity;

public class Employee
{
    public int Id { get; init; }
    public string BankAccount { get; private set; }

    public Employee(int id, string bankAccount)
    {
        //^(\d{26}|\d{2} (\d{4} ){5}\d{4})$

        Id = id;
        BankAccount = bankAccount;
    }

    /// <exception cref="InvalidBankAccountException" />
    public void ChangeBankAccount(string newBankAccount)
    {
        if (!Regex.IsMatch(newBankAccount, @"^(\d{26}|\d{2} (\d{4} ){5}\d{4})$"))
        {
            throw InvalidBankAccountException.Default(newBankAccount);
        }

        BankAccount = newBankAccount;
    }
}
