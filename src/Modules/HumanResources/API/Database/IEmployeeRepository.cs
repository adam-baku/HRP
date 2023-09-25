namespace HRP.Module.HumanResources.API;

public interface IEmployeeRepository
{
    Task AddAsync(Employee employee);
    Task DeleteAsync(int id);
    Task<List<Employee>> GetAllAsync();
    Task<Employee?> GetByIdAsync(int id);
    Task UpdateAsync(Employee employee);
}
