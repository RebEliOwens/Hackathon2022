namespace HackathonBackend.Models
{
    public class Dispatcher
    {
        public int Id { get; set; }
        public string CarrierName { get; set; }
        public int DispatcherId { get; set; }
        public string DispatcherName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
    }
}
