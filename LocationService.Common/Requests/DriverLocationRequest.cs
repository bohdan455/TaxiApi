using System.ComponentModel.DataAnnotations;

namespace LocationService.Requests;

public class DriverLocationRequest
{
    [Required]
    public string DriverId { get; set; }
    
    [Range(-90, 90)]
    public double Latitude { get; set; }
    
    [Range(-180, 180)]
    public double Longitude { get; set; }
}