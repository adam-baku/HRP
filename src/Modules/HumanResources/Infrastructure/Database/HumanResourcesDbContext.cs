using HRP.Module.HumanResources.API;
using HRP.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HRP.Module.HumanResources.Infrastructure;

public class HumanResourcesDbContext : DbContextBase, IEmployeeRepository
{
    public DbSet<Employee> Employees { get; set ;}

    protected override string Schema => "humanresources";

    public HumanResourcesDbContext(IConfiguration configuration)
        : base(configuration) {}

    public HumanResourcesDbContext(DbContextOptions<HumanResourcesDbContext> options, IConfiguration configuration)
        : base(options, configuration) {}

    public Task AddAsync(Employee employee)
    {
        Employees.Add(employee);

        return SaveChangesAsync();
    }

    public Task DeleteAsync(int id)
    {
        return Employees.Where(x => x.Id == id)
            .ExecuteDeleteAsync();
    }

    public Task<List<Employee>> GetAllAsync()
    {
        return Employees.AsNoTracking()
            .Include(x => x.Address)
            .AsNoTracking()
            .ToListAsync();
    }

    public Task<Employee?> GetByIdAsync(int id)
    {
        return Employees.AsNoTracking()
            .Include(x => x.Address)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public Task UpdateAsync(Employee employee)
    {
        Employees.Update(employee);
        
        return SaveChangesAsync();
    }
}
