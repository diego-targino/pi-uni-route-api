using AutoMapper;
using UniRoute.Domain.DTO.Response.BusStop;
using UniRoute.Domain.Entities;
using UniRoute.Domain.Interfaces.Repositories;
using UniRoute.Domain.Interfaces.Services;

namespace UniRoute.Application.Services;

public class BusStopService(IUnitOfWork unitOfWork, IMapper mapper) : IBusStopService
{
    public async Task<IEnumerable<BusStopDTO>> GetAllAsync()
    {
        IEnumerable<BusStop> busStops = await unitOfWork.BusStopRepository.GetAllAsync();

        IEnumerable<BusStopDTO> busStopDTOs = mapper.Map<IEnumerable<BusStopDTO>>(busStops);

        return busStopDTOs;
    }

    public async Task<IEnumerable<StopTimeDTO>> GetStopTimesAsync(long busStopId)
    {
        IEnumerable<StopTime> stopTimes = await unitOfWork.StopTimeRepository.GetAllAsync(x => x.BusStopId == busStopId);

        IEnumerable<StopTimeDTO> stopTimeDTOs = mapper.Map<IEnumerable<StopTimeDTO>>(stopTimes);

        return stopTimeDTOs;
    }
}
