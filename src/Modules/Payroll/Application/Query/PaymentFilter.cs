namespace HRP.Module.Payroll.Application.Query;

public record struct PaymentFilter(DateOnly? PaidAt, string? BankAccount)
{

}
