using System;
using System.Collections.Generic;

namespace CarPool.Trip.Domain.Entities
{
    public class EventTrip
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public int DriverId { get; set; }
        public DateTime TripStartTime { get; set; }
        public string Address { get; set; }
        public int Capacity { get; set; }
        public Event Event { get; set; }
        public Participant Driver { get; set; }
        public ICollection<TripJoinRequest> TripJoinRequests { get; set; }
    }
}
