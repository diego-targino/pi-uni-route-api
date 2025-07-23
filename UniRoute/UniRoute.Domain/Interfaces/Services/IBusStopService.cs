using UniRoute.Domain.DTO.Response.BusStop;

namespace UniRoute.Domain.Interfaces.Services;

public interface IBusStopService
{
    Task<IEnumerable<BusStopDTO>> GetAllAsync();

    Task<IEnumerable<StopTimeDTO>> GetStopTimesAsync(long busStopId);
}
