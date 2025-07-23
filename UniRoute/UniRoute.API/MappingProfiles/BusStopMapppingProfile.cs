using AutoMapper;
using UniRoute.Domain.DTO.Response.BusStop;
using UniRoute.Domain.Entities;

namespace UniRoute.API.MappingProfiles;

public class BusStopMapppingProfile : Profile
{
    public BusStopMapppingProfile()
    {
        CreateMap<BusStop, BusStopDTO>();

        CreateMap<StopTime, StopTimeDTO>();
    }
}
