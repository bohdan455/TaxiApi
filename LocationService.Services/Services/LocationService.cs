using LocationService.Services.Services.Interfaces;
using StackExchange.Redis;

namespace LocationService.Services.Services;

public class LocationService : ILocationService
{
    private readonly IDatabase _redis;

    public LocationService(IDatabase redis)
    {
        _redis = redis;
    }
    
    public async Task SetDriverLocation(string driverId, double latitude, double longitude)
    {
        await _redis.GeoAddAsync("driver:location", longitude, latitude, driverId);
    }
}