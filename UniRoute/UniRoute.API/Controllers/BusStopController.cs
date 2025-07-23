using Microsoft.AspNetCore.Mvc;
using UniRoute.Domain.Interfaces.Services;

namespace UniRoute.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusStopController(IBusStopService busStopService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var busStops = await busStopService.GetAllAsync();

            return StatusCode(StatusCodes.Status200OK, busStops);
        }

        [HttpGet("{busStopId}/stop-times")]
        public async Task<IActionResult> GetStopTimes(long busStopId)
        {
            var stopTimes = await busStopService.GetStopTimesAsync(busStopId);

            return StatusCode(StatusCodes.Status200OK, stopTimes);
        }
    }
}
