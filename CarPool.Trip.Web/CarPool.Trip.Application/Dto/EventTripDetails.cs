using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool.Trip.Application.Dto
{
    public class EventTripDetails
    {
        public string EventName { get; }
        public string EventAddress { get; }
        public string DepartureAddress { get; set; }
        public DateTime DepartureTime { get; set; }
        public DriverDto Driver { get; set; }

    }
}
