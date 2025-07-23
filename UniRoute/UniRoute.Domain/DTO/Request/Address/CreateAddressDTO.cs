namespace UniRoute.Domain.DTO.Request.Address;

public class CreateAddressDTO
{
    public long StudentId { get; set; }

    public string? Street { get; set; }

    public string? PostalCode { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}
