using System;
using System.Collections.Generic;

namespace CarPool.Trip.Application.Dto
{
    public class EventTripDetails
    {
        public string EventName { get; set; }
        public string EventAddress { get; set; }
        public string DepartureAddress { get; set; }
        public DateTime DepartureTime { get; set; }
        public DriverDto Driver { get; set; }
        public IEnumerable<TripJoinRequestDto> TripJoinRequests { get; set; }
    }
}
