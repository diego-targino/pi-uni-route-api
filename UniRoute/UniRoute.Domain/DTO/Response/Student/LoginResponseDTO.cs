namespace UniRoute.Domain.DTO.Response.Student;

public class LoginResponseDTO
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? Mail { get; set; }

    public string? Token { get; set; }

    public AddressDTO? Address { get; set; }
}
