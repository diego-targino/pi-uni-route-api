using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniRoute.Domain.Entities;

namespace UniRoute.Infrastructure.Data.EntitiesConfigurations;

public class StopTimeConfiguration : IEntityTypeConfiguration<StopTime>
{
    public void Configure(EntityTypeBuilder<StopTime> builder)
    {
        builder.ToTable("StopTimes");

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
            .ValueGeneratedOnAdd();

        builder.Property(s => s.BusType)
            .IsRequired();

        builder.Property(s => s.ExpectedTime)
            .IsRequired();
    }
}
