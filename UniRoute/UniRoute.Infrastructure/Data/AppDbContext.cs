using Microsoft.EntityFrameworkCore;
using UniRoute.Domain.Entities;

namespace UniRoute.Infrastructure.Data;

public class AppDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Student> Students => Set<Student>();

    public DbSet<Address> Addresses => Set<Address>();

    public DbSet<BusStop> BusStops => Set<BusStop>();

    public DbSet<StopTime> StopTimes => Set<StopTime>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
