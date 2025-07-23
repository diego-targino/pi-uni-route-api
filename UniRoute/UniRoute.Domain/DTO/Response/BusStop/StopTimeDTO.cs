using UniRoute.Domain.Enums;

namespace UniRoute.Domain.DTO.Response.BusStop;

public class StopTimeDTO
{
    public long Id { get; set; }

    public BusType BusType { get; set; }

    public TimeSpan ExpectedTime { get; set; }
}
