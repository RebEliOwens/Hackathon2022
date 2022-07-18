using System.ComponentModel.DataAnnotations;

namespace HackathonBackend.Models
{
    public class tblPayTruck
    {
        [Key]
        public int RowId { get; set; }

        public int PONumber { get; set; }

        public int Rate { get; set; }

        public int CarrierId { get; set; }
        public virtual tblCarrier? Carrier { get; set; } = null!;


        }
    }
