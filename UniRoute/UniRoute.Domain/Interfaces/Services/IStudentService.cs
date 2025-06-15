using UniRoute.Domain.DTO.Student;

namespace UniRoute.Domain.Interfaces.Services;

public interface IStudentService
{
    public Task CreateAsync(CreateStudentDTO createStudentDTO);
}
