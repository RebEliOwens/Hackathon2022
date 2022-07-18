using System.ComponentModel.DataAnnotations;

namespace HackathonBackend.Models
    {
    public class tblDriver
        {
        [Key]
        public int DriverId { get; set; }

        public string DriverName { get; set; } = "";

        public int CarrierId { get; set; }
        public virtual tblCarrier Carrier { get; set; } = null!;
        }
    }
