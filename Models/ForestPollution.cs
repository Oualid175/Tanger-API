using System;
using System.ComponentModel.DataAnnotations;

namespace Tanger_API.Models
{
    public class ForestPollution
    {
        [Key]
        public int ForestPollutionId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public string Pollutant { get; set; } = "";
        [Required]
        public string Severity { get; set; } = "";
        [Required]
        public DateTime Timestamp { get; set; }
    }
}
