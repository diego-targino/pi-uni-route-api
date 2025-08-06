using AutoMapper;
using UniRoute.Domain.DTO.Request.Student;
using UniRoute.Domain.DTO.Response.Student;
using UniRoute.Domain.Entities;
using UniRoute.Domain.Exceptions;
using UniRoute.Domain.Interfaces.Repositories;
using UniRoute.Domain.Interfaces.Services;
using UniRoute.Domain.Messages;

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
                throw new BadRequestException(BusinessMessages.Sutudent_Mail_Already_Exists);

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

    public async Task<LoginResponseDTO> LoginAsync(LoginDTO loginDTO)
    {
        Student student = await unitOfWork.StudentRepository.GetByMailAsync(loginDTO.Mail)
            ?? throw new BadRequestException(BusinessMessages.Student_Login_Fail);

        if (!cryptographyService.VerifyPassword(student.Password, loginDTO.Password!, student.Salt))
            throw new BadRequestException(BusinessMessages.Student_Login_Fail);

        LoginResponseDTO loginResponseDTO = mapper.Map<LoginResponseDTO>(student);

        Address? address = await unitOfWork.AddressRepository.GetByStudentIdAsync(student.Id);

        loginResponseDTO.Address = mapper.Map<AddressDTO?>(address);

        return loginResponseDTO;
    }
}
