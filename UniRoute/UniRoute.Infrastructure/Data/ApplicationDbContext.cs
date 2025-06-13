using Microsoft.EntityFrameworkCore;
using UniRoute.Domain.Entities;

namespace UniRoute.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Student> Students => Set<Student>();

    public DbSet<Address> Addresses => Set<Address>();

    public DbSet<BusStop> BusStops => Set<BusStop>();

    public DbSet<StopTime> StopTimes => Set<StopTime>();
}
