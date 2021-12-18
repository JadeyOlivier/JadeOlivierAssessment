using Microsoft.EntityFrameworkCore;
using JAOAssessment.Models;

namespace JAOAssessment.Data
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }  
        
    }
}
