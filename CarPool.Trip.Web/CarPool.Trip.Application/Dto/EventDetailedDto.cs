using System.Collections.Generic;

namespace CarPool.Trip.Application.Dto
{
    public class EventDetailedDto
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string LogoUri { get; set; }

        public IEnumerable<EventTripDto> EventTrips { get; set; }

        public class EventTripDto
        {
            public int Id { get; set; }
            public string Address { get; set; }
            public int Capacity { get; set; }
            public int CurrentPassengerCount { get; set; }
            public string CarModel { get; set; }
            public string DriverName { get; set; }
        }
    }
}
