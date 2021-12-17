namespace JAOAssessment.Models
{
    public class Vehicle
    {
        public string ID { get; set; }
        public string VehicleKey { get; set; }
        public string EngineKey { get; set; }
        public string PaintKey { get; set; }
        public string InteriorKey { get; set; }
        public int QuantityOnHand { get; set; }
        public float Price { get; set; }
    }
}
