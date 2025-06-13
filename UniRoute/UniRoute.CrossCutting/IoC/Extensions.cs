using Microsoft.Extensions.DependencyInjection;
using UniRoute.Domain.Interfaces.Repositories;
using UniRoute.Infrastructure.Data;
using UniRoute.Infrastructure.Repositories;

namespace UniRoute.CrossCutting.IoC;

public static class Extensions
{
    public static IServiceCollection AddRepositoriesDI(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>();
        // TODO: Add database

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IBusStopRepository, BusStopRepository>();
        services.AddScoped<IStopTimeRepository, StopTimeRepository>();

        return services;
    }
}
