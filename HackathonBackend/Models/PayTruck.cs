namespace HackathonBackend.Models
{
    public class PayTruck
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal Rate { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }

        public int PONumber { get; set; }
        public virtual Load Load { get; set; }
    }
}
