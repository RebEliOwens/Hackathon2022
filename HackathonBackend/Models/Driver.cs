namespace HackathonBackend.Models
    {
    public class Driver
        {
        public int DriverId { get; set; }

        public string DriverName { get; set; } = "";

        public int CarrierId { get; set; }
        public virtual Carrier Carrier { get; set; } = null!;
        }
    }
