using Microsoft.EntityFrameworkCore;

namespace JAOAssessment.Models
{
    [Keyless]
    public class FullVehicleDetail
    {
        public string Model { get; set; }
        public string BaseYear { get; set; }
        public decimal BasePrice { get; set; }
        public string EngineFuel { get; set; }
        public string EngineCapacity { get; set; }
        public int EnginePower { get; set; }
        public decimal EnginePrice { get; set; }
        public string InteriorName { get; set; }
        public string Seats { get; set; }
        public string Dash { get; set; }
        public string Carpet { get; set; }
        public string Headliner { get; set; }
        public decimal InteriorPrice { get; set; }
        public string PaintName { get; set; }
        public string PaintFinish { get; set; }
        public decimal PaintPrice { get; set; }

    }
}
