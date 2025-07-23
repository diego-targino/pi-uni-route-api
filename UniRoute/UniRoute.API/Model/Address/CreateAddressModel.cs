namespace UniRoute.API.Model.Address;

public class CreateAddressModel
{
    public long? StudentId { get; set; }

    public string? Street { get; set; }

    public string? PostalCode { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}
