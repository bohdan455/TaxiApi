using LocationService.Requests;
using LocationService.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace LocationService.Controllers;

[Route("location")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;

    public LocationController(ILocationService locationService)
    {
        _locationService = locationService;
    }
    
    [HttpPost("update")]
    public async Task<IActionResult> UpdateDriverLocation([FromBody] DriverLocationRequest locationRequest)
    {
        await _locationService.SetDriverLocation(locationRequest.DriverId, locationRequest.Latitude,
            locationRequest.Longitude);

        return Ok();
    }
}