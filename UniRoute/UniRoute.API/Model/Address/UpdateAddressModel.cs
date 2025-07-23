namespace UniRoute.API.Model.Address;

public class UpdateAddressModel
{
    public string? Street { get; set; }

    public string? PostalCode { get; set; }

    public decimal? Latitude { get; set; }

    public decimal? Longitude { get; set; }
}
