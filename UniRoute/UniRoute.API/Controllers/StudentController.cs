using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UniRoute.API.Model.Student;
using UniRoute.Domain.DTO.Student;
using UniRoute.Domain.Interfaces.Services;

namespace UniRoute.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController(IStudentService studentService, IMapper mapper) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStudentModel createStudentModel)
    {
        CreateStudentDTO createStudentDTO = mapper.Map<CreateStudentDTO>(createStudentModel);

        await studentService.CreateAsync(createStudentDTO);

        return StatusCode(StatusCodes.Status201Created);
    }
}
