using System.ComponentModel.DataAnnotations;

namespace Tanger_API.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "";
        public string? Description { get; set; }
        public float Calories { get; set; }
    }
}
