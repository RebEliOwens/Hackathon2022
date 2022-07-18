using System.ComponentModel.DataAnnotations;

namespace HackathonBackend.Models
{
    public class PayTruck
    {
        [Key]
        public int RowId { get; set; }

        public int PONumber { get; set; }

        public int Rate { get; set; }

        public int CarrierId { get; set; }
        public virtual Carrier? Carrier { get; set; } = null!;


        }
    }
