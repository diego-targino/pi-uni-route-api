using UniRoute.Domain.Entities;
using UniRoute.Domain.Interfaces.Base;

namespace UniRoute.Domain.Interfaces.Repositories;

public interface IStudentRepository : IBaseRepository<Student>
{
    Task<Student?> GetByMailAsync(string? mail);
}
