using UniRoute.Domain.Entities.Base;

namespace UniRoute.Domain.Interfaces.Base;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task CreateAsync(T entity);

    Task<T?> GetByIdAsync(long id, bool isTracking = true);

    void Update(T Entity);

    Task DeleteByIdAsync(long id);
}
