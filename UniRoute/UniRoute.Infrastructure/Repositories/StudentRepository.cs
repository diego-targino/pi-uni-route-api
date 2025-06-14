using UniRoute.Domain.Entities;
using UniRoute.Domain.Interfaces.Repositories;
using UniRoute.Infrastructure.Data;
using UniRoute.Infrastructure.Repositories.Base;

namespace UniRoute.Infrastructure.Repositories;

public class StudentRepository(AppDbContext appDbContext) : BaseRepository<Student>(appDbContext), IStudentRepository
{
}
