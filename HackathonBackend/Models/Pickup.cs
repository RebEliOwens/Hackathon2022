namespace HackathonBackend.Models
{
    public class Pickup
    {
        public int Id { get; set; }
        public string PickName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int PONumber { get; set; }
        public virtual Load Load { get; set; }
    }
}
