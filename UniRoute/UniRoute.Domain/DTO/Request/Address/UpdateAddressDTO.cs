namespace UniRoute.Domain.DTO.Request.Address;

public class UpdateAddressDTO
{
    public long Id { get; set; }

    public string? Street { get; set; }

    public string? PostalCode { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}
