namespace HackathonBackend.Models
{
    public class Loads
    {
        public int Id { get; set; }


        public string CarrierName { get; set; } = "";
        public int DriverId { get; set; }
        public string DriverName { get; set; } = "";
        public string DriverCellNumber { get; set; } = "";
        public string Dispatcher { get; set; } = "";
        public string Lane { get; set; } = "";
        public string Customer { get; set; } = "";

        public int CarrierId { get; set; }
        public virtual Carrier? Carrier { get; set; } = null!;


        public List<Pickups> Pickups { get; set; } 
        public List<Drops> Drops { get; set; }

    }
}
