using MatchingService.Common.Response;

namespace MatchingService.Services.Services.Interfaces;

public interface IRideService
{
    Task<MatchRideResponse> Match(double latitude, double longitude);
}