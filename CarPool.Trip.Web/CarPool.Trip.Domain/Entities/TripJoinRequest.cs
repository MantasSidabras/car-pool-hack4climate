namespace CarPool.Trip.Domain.Entities
{
    public class TripJoinRequest
    {
        public int Id { get; set; }
        public Participant Passenger { get; set; }
        public Trip Trip { get; set; }
    }
}
