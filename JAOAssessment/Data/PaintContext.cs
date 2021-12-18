namespace JAOAssessment.Data
{
    public class PaintContext
    {
        public PaintContext(DbContextOptions<PaintContext> options) : base(options) { }

        public DbSet<Paint> Vehicles { get; set; }

        
    }
}
