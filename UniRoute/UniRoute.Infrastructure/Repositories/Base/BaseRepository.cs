using UniRoute.Domain.Entities.Base;
using UniRoute.Domain.Interfaces.Base;

namespace UniRoute.Infrastructure.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    public Task CreateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<T?> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T Entity)
    {
        throw new NotImplementedException();
    }
}
