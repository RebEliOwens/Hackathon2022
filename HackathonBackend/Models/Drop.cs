namespace HackathonBackend.Models
{
    public class Drop
    {
        public int Id { get; set; }
        public string DropName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public int PONumber { get; set; }
        public virtual Load Load { get; set; }
    }
}
