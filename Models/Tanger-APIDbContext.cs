using Microsoft.EntityFrameworkCore;

namespace Tanger_API.Models
{
    public class Tanger_APIDbContext : DbContext
    {
        public Tanger_APIDbContext(DbContextOptions<Tanger_APIDbContext> options) 
            : base(options) { }
        
        public DbSet<Food> Foods { get; set; }
        public DbSet<AirPollution> AirPollutions { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ForestPollution> ForestPollutions { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        public DbSet<WaterWaste> WaterWastes { get; set; } 

    }
}
