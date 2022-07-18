using System.ComponentModel.DataAnnotations;

namespace HackathonBackend.Models
{
    public class tblDrops
    {
        [Key]
        public int RowId { get; set; }

        public int PONumber { get; set; }

        public string City { get; set; } = "";

        public string State { get; set; } = "";

        public string Address1 { get; set; } = "";
        public string Address2 { get; set; } = "";
        public string Zip { get; set; } = "";


        }
}
