using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HRP.Shared;

public abstract class DbContextBase : DbContext
{
    private const string CONNECTION_STRING_NAME = "Hrp";
    protected abstract string Schema { get; }

    protected readonly IConfiguration configuration;

    protected DbContextBase(IConfiguration configuration)
        : this(new DbContextOptions<DbContextBase>(), configuration) {}

    protected DbContextBase(DbContextOptions options, IConfiguration configuration)
        : base(options)
    {
        this.configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(configuration.GetConnectionString(CONNECTION_STRING_NAME));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}
