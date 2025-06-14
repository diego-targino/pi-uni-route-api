using UniRoute.Domain.Entities.Base;

namespace UniRoute.Domain.Entities;

public class BusStop : BaseEntity
{
    public string Name { get; set; }

    public string AddressDatails { get; set; }

    public string ReferencePoint { get; set; }

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public IEnumerable<StopTime>? StopTimes { get; set; }
}
