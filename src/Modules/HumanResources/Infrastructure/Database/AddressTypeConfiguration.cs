using HRP.Module.HumanResources.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRP.Module.HumanResources.Infrastructure.Database;

public class AddressTypeConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Address");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Country)
            .HasMaxLength(250);
        builder.Property(x => x.City)
            .HasMaxLength(250);
        builder.Property(x => x.Street)
            .HasMaxLength(1000);
    }
}
