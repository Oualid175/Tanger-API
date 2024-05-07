using System.ComponentModel.DataAnnotations;

namespace Tanger_API.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; } = "";
        [Required]
        public string Country { get; set; } = "";
    }
}
