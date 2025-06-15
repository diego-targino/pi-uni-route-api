using AutoMapper;
using UniRoute.API.Model.Student;
using UniRoute.Domain.DTO.Request.Student;
using UniRoute.Domain.Entities;

namespace UniRoute.API.MappingProfiles;

public class StudentMappingProfile : Profile
{
    public StudentMappingProfile()
    {
        CreateMap<CreateStudentModel, CreateStudentDTO>();
        CreateMap<CreateStudentDTO, Student>();

        CreateMap<LoginModel, LoginDTO>();
    }
}
