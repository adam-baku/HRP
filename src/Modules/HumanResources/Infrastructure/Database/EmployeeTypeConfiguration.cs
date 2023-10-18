using HRP.Module.HumanResources.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRP.Module.HumanResources.Infrastructure.Database;

public class EmployeeTypeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employee");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(250);
        builder.Property(x => x.LastName)
            .HasMaxLength(250);
        builder.Property(x => x.Department)
            .HasConversion<string>()
            .HasMaxLength(250);
        builder.Property(x => x.FormOfEmployment)
            .HasConversion<string>()
            .HasMaxLength(50);
        builder.Property(x => x.OptionOfEmployment)
            .HasConversion<string>()
            .HasMaxLength(50);
        builder.Property(x => x.EmployedOn)
            .HasConversion<DateTime>()
            .HasPrecision(3);
        builder.Property<DateTime>("CreatedAt")
            .HasPrecision(3)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETUTCDATE()");
        builder.Property<DateTime>("UpdatedAt")
            .HasPrecision(3)
            .ValueGeneratedOnAddOrUpdate()
            .HasDefaultValueSql("GETUTCDATE()");

        builder.HasOne(x => x.Address)
            .WithOne()
            .HasForeignKey<Address>("EmployeeId")
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
