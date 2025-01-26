namespace LocationService.Services.Services.Interfaces;

public interface ILocationService
{
    public Task SetDriverLocation(string driverId, double latitude, double longitude);
}