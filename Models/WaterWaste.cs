using System;
using System.ComponentModel.DataAnnotations;

namespace Tanger_API.Models
{
    public class WaterWaste
    {
        [Key]
        public int WaterWasteId { get; set; }
        [Required]
        public int LocationId { get; set; }
        [Required]
        public string WasteType { get; set; } = "";
        [Required]
        public string WasteVolume { get; set; } = "";
        [Required]
        public DateTime Timestamp { get; set; }
    }
}
