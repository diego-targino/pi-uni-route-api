﻿namespace UniRoute.Domain.Interfaces.Repositories;

public interface IUnitOfWork : IAsyncDisposable
{
    IStudentRepository StudentRepository { get; }

    IAddressRepository AddressRepository { get; }

    IBusStopRepository BusStopRepository { get; }

    IStopTimeRepository StopTimeRepository { get; }

    Task BeginTransactionAsync();

    Task CommitAsync();

    Task RollbackAsync();
}
