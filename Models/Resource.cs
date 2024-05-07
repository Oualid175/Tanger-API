using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tanger_API.Models
{
    public class Resource
    {
        [Required]
        public City City { get; set; }
        [Required]
        public List<Location> Locations { get; set; }
        [Required]
        public List<AirPollution> AirPollution { get; set; }
        [Required]
        public List<WaterWaste> WaterWaste { get; set; }
        [Required]
        public List<ForestPollution> ForestPollution { get; set; }
    }
}
