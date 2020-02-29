namespace CarPool.Trip.Application.Dto
{
    public class TripJoinRequestDto
    {
        public PassengerDto Passenger { get; set; }
        public bool? Approved { get; set; }
        public string Address { get; set; }
    }
}
