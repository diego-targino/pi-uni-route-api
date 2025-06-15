using UniRoute.Domain.DTO.Request.Student;
using UniRoute.Domain.DTO.Response.Student;

namespace UniRoute.Domain.Interfaces.Services;

public interface IStudentService
{
    public Task CreateAsync(CreateStudentDTO createStudentDTO);

    public Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO);
}
