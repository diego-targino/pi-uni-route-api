using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using UniRoute.Domain.Interfaces.Repositories;
using UniRoute.Infrastructure.Data;

namespace UniRoute.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ApplicationDbContext _applicationDbContext;

    private IStudentRepository? _studentRepository;
    private IAddressRepository? _addressRepository;
    private IBusStopRepository? _busStopRepository;
    private IStopTimeRepository? _stopTimeRepository;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(IServiceProvider serviceProvider, ApplicationDbContext applicationDbContext)
    {
        _serviceProvider = serviceProvider;
        _applicationDbContext = applicationDbContext;
    }

    public IStudentRepository StudentRepository
    {
        get
        {
            _studentRepository ??= _serviceProvider.GetRequiredService<IStudentRepository>();

            return _studentRepository;
        }
    }

    public IAddressRepository AddressRepository
    {
        get
        {
            _addressRepository ??= _serviceProvider.GetRequiredService<IAddressRepository>();

            return _addressRepository;
        }
    }

    public IBusStopRepository BusStopRepository
    {
        get
        {
            _busStopRepository ??= _serviceProvider.GetRequiredService<IBusStopRepository>();

            return _busStopRepository;
        }
    }

    public IStopTimeRepository StopTimeRepository
    {
        get
        {
            _stopTimeRepository ??= _serviceProvider.GetRequiredService<IStopTimeRepository>();

            return _stopTimeRepository;
        }
    }

    public async Task BeginTransactionAsync()
    {
        _transaction ??= await _applicationDbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction is not null)
            await _transaction.CommitAsync();
    }

    public async Task RollbackAsync()
    {
        if (_transaction is not null)
            await _transaction.CommitAsync();
    }
}
