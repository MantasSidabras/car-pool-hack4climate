namespace CarPool.Trip.Domain.Entities
{
    public class TripJoinRequest
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int EventTripId { get; set; }
        public Participant Passenger { get; set; }
        public EventTrip Trip { get; set; }
    }
}
