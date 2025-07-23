namespace UniRoute.Domain.DTO.Response.Address;

public class AddressDTO
{
    public long Id { get; set; }

    public long StudentId { get; set; }

    public string? Street { get; set; }

    public string? PostalCode { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}
