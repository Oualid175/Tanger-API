using System.ComponentModel.DataAnnotations;

namespace Tanger_API.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string Address { get; set; } = "";
    }

}
