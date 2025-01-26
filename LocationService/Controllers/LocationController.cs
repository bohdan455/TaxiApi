using LocationService.Requests;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LocationService.Controllers;

[Route("location")]
[ApiController]
public class LocationController : ControllerBase
{
    [HttpPost("update")]
    public async Task<IActionResult> UpdateDriverLocation([FromBody] GeoLocation location)
    {
        return Ok(location);
    }
    
}