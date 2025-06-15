using AutoMapper;
using UniRoute.Domain.DTO.Student;
using UniRoute.Domain.Entities;
using UniRoute.Domain.Interfaces.Repositories;
using UniRoute.Domain.Interfaces.Services;

namespace UniRoute.Application.Services;

public class StudentService(IUnitOfWork unitOfWork, ICryptographyService cryptographyService, IMapper mapper) : IStudentService
{
    public async Task CreateAsync(CreateStudentDTO createStudentDTO)
    {
        await unitOfWork.BeginTransactionAsync();

        try
        {
            Student? student = await unitOfWork.StudentRepository.GetByMailAsync(createStudentDTO.Mail);

            if (student is not null)
                throw new Exception("Email já registrado patrão");

            student = mapper.Map<Student>(createStudentDTO);

            student.Password = cryptographyService.Encrypth(createStudentDTO.Password!, out long salt);
            student.Salt = salt;

            await unitOfWork.StudentRepository.CreateAsync(student);

            await unitOfWork.CommitAsync();
        }
        catch (Exception)
        {
            await unitOfWork.RollbackAsync();

            throw;
        }
    }
}
