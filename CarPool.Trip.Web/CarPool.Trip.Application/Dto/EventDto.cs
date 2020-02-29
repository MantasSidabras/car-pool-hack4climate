using System;

namespace CarPool.Trip.Application.Dto
{
    public class EventDto
    {
        public int Id { get; set; }
        public DateTime EventTime { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string LogoUri { get; set; }
    }
}
