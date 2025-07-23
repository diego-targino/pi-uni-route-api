using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using UniRoute.Domain.Entities.Base;
using UniRoute.Domain.Interfaces.Base;
using UniRoute.Domain.Messages;
using UniRoute.Infrastructure.Data;

namespace UniRoute.Infrastructure.Repositories.Base;

public class BaseRepository<T>(AppDbContext appDbContext) : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _appDbContext = appDbContext;

    public async Task CreateAsync(T entity)
    {
        await _appDbContext.Set<T>().AddAsync(entity);
    }

    public async Task DeleteByIdAsync(long id)
    {
        T? entity = await _appDbContext.Set<T>().FindAsync(id) ??
            throw new Exception(RepositoryMessages.Delete_NotFound);

        _appDbContext.Set<T>().Remove(entity);
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        IQueryable<T> query = _appDbContext.Set<T>().AsNoTracking();

        if (filter is not null)
            query = query.Where(filter);

        return await query.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(long id, bool isTracking = true)
    {
        var consultQuery = _appDbContext.Set<T>();

        if (!isTracking)
            consultQuery.AsNoTracking();

        return await consultQuery.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Update(T entity)
    {
        _appDbContext.Set<T>().Update(entity);
    }
}
