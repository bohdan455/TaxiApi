using MatchingService.Common.Requests;
using MatchingService.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MatchingService.Controllers;

[Route("route")]
[ApiController]
public class RideController : ControllerBase
{
    private readonly IRideService _rideService;

    public RideController(IRideService rideService)
    {
        _rideService = rideService;
    }
    
    [HttpPost("request")]
    public async Task<IActionResult> RequestRide(MatchRideRequest request)
    {
        var result = await _rideService.Match(request.Latitude, request.Longitude);
        
        
        return Ok(result);
    }
}