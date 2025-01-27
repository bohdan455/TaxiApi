using MatchingService.Common.Response;
using MatchingService.Services.Services.Interfaces;
using StackExchange.Redis;

namespace MatchingService.Services.Services;

public class RideService : IRideService
{
    private readonly IDatabase _rider;

    public RideService(IDatabase rider)
    {
        _rider = rider;
    }
    
    public async Task<MatchRideResponse> Match(double latitude, double longitude)
    {
        const int searchRadius = 1000;
        var result = await _rider.GeoRadiusAsync("driver:location", longitude, latitude, count: 1,
            order: Order.Ascending, radius: searchRadius, unit: GeoUnit.Kilometers);
        var driver = result.First();
        return new MatchRideResponse
        {
            Longitude = driver.Position.Value.Longitude,
            Latitude = driver.Position.Value.Latitude,
            Distance = driver.Distance ?? 0,
            DriverId = driver.Member
        };
    }
}