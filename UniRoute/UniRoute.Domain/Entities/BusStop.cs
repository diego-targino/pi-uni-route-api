using UniRoute.Domain.Entities.Base;

namespace UniRoute.Domain.Entities;

public class BusStop : BaseEntity
{
    public string Name { get; set; }
    
    public string ReferencePoint { get; set; }
    
    public decimal Longitude { get; set; }

    public List<BusStop>? BusStops { get; set; }
}
