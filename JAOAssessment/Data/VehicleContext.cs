using Microsoft.EntityFrameworkCore;
using JAOAssessment.Models;

namespace JAOAssessment.Data
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Paint> Paints { get; set; }
        public DbSet<Engine> Engines { get; set; }
        public DbSet<Interior> Interiors { get; set; }
        public DbSet<BaseVehicle> BaseVehicles { get; set; }
        public DbSet<FullVehicleDetail> FullVehicleDetails { get; set; } 

    }
}
