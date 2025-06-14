using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniRoute.Domain.Entities;

namespace UniRoute.Infrastructure.Data.EntitiesConfigurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable("Addresses");

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Street)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(a => a.PostalCode)
            .IsRequired()
            .HasMaxLength(8);

        builder.Property(a => a.Latitude)
            .IsRequired()
            .HasPrecision(9, 6);

        builder.Property(a => a.Longitude)
            .IsRequired()
            .HasPrecision(9, 6);
    }
}
