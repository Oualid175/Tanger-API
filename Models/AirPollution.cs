using System;
using System.ComponentModel.DataAnnotations;

namespace Tanger_API.Models
{
    public class AirPollution
    {
        [Key]
        public int AirPollutionId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public string Pollutant { get; set; } = "";
        [Required]
        public string PollutantLevel { get; set; } = "";
        [Required]
        public DateTime Timestamp { get; set; }
    }
}
