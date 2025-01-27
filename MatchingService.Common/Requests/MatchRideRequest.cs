using System.ComponentModel.DataAnnotations;

namespace MatchingService.Common.Requests;

public class MatchRideRequest
{
    [Range(-90, 90)]
    public double Latitude { get; set; }
    
    [Range(-180, 180)]
    public double Longitude { get; set; }
}