using System.ComponentModel.DataAnnotations;
using System.Text;



namespace HackathonBackend.Models
{

    public class tblCarrier
    {
        [Key]
        public int CarrierId { get; set; }
        public string CarrierName { get; set; } = "";
        public string MCNumber { get; set; } = "";
        public string Email { get; set; } = "";

        }
}
