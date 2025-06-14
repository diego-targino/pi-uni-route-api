using Microsoft.EntityFrameworkCore.Storage;
using UniRoute.Domain.Interfaces.Repositories;
using UniRoute.Infrastructure.Data;

namespace UniRoute.Infrastructure.Repositories;

public class UnitOfWork(
    AppDbContext appDbContext,
    IStudentRepository studentRepository,
    IAddressRepository addressRepository,
    IBusStopRepository busStopRepository,
    IStopTimeRepository stopTimeRepository) : IUnitOfWork
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public IStudentRepository StudentRepository { get; } = studentRepository;
    public IAddressRepository AddressRepository { get; } = addressRepository;
    public IBusStopRepository BusStopRepository { get; } = busStopRepository;
    public IStopTimeRepository StopTimeRepository { get; } = stopTimeRepository;

    private IDbContextTransaction? _transaction;

    public async Task BeginTransactionAsync()
    {
        if (_transaction is not null)
            return;

        _transaction = await _appDbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
    public async ValueTask DisposeAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}
