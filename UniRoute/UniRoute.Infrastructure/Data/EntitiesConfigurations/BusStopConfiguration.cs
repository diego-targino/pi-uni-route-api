using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniRoute.Domain.Entities;

namespace UniRoute.Infrastructure.Data.EntitiesConfigurations;

public class BusStopConfiguration : IEntityTypeConfiguration<BusStop>
{
    public void Configure(EntityTypeBuilder<BusStop> builder)
    {
        builder.ToTable("BusStops");

        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(b => b.ReferencePoint)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.AddressDatails)
            .IsRequired();

        builder.Property(b => b.Latitude)
            .IsRequired()
            .HasPrecision(9, 6);

        builder.Property(b => b.Longitude)
            .IsRequired()
            .HasPrecision(9, 6);

        builder.HasMany(b => b.StopTimes)
            .WithOne(s => s.BusStop)
            .HasForeignKey(s => s.BusStopId);
    }
}
