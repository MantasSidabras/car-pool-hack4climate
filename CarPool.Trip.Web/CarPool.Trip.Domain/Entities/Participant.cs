using System.Collections.Generic;

namespace CarPool.Trip.Domain.Entities
{
    public class Participant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Carplate { get; set; }
        public string CarModel { get; set; }
        public ICollection<EventTrip> DrivingAt { get; set; }
        public ICollection<TripJoinRequest> TripJoinRequests { get; set; }
    }
}
