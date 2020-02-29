namespace CarPool.Trip.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
