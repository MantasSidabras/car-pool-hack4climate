using System.Collections.Generic;

namespace CarPool.Trip.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string LogoUri { get; set; }
        public string Address { get; set; }
        public ICollection<EventTrip> EventTrips { get; set; }
    }
}
