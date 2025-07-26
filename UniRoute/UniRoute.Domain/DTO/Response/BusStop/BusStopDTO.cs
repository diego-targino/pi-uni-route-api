namespace UniRoute.Domain.DTO.Response.BusStop;

public class BusStopDTO
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public string? AddressDatails { get; set; }

    public string? ReferencePoint { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }
}
