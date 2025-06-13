using UniRoute.Domain.Entities.Base;
using UniRoute.Domain.Enums;

namespace UniRoute.Domain.Entities;

public class StopTime : BaseEntity
{
    public long BusStopId { get; set; }

    public BusType BusType { get; set; }

    public TimeSpan ExpectedTime { get; set; }

    public BusStop BusStop { get; set; }
}
