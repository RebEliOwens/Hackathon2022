using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HackathonBackend.Models
{
    [Index(nameof(PONumber), IsUnique = true)]
    public class Load
    {
        public int Id { get; set; }
        public int PONumber { get; set; }
        public int CarrierId { get; set; }
        public string CarrierName { get; set; }
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string DriverCellNumber { get; set; }
        public string Dispatcher { get; set; }
        public string Lane { get; set; }
        public string Customer { get; set; }

        public List<Pickup> Pickups { get; set; }
        public List<Drop> Drops { get; set; }

    }
}
