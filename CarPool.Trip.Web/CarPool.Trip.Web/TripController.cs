using CarPool.Trip.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarPool.Trip.Web
{
    [ApiController]
    public class TripController : ControllerBase
    {
        [HttpGet("health")]
        public IActionResult Health()
        {
            return Ok("Healthy");
        }

        [HttpGet("events")]
        public Event[] Events()
        {
            throw new NotImplementedException();
        }

        [HttpGet("event/trips/{eventId}")]
        public EventTrip[] EventTrips([FromRoute] int eventId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("trip/init/{eventId}")]
        public int InitiateTrip(
            [FromRoute] int eventId, 
            [FromBody] StartDetails startDetails)
        {
            throw new NotImplementedException();
        }

        [HttpPost("trip/join/{tripId}")]
        public TripJoinRequest JoinTrip(
            [FromRoute] int tripId,
            [FromBody] Point passengerLocation)
        {
            throw new NotImplementedException();
        }

        [HttpPost("trip-request/approve/{tripJoinRequestId}")]
        public IActionResult ApproveTripRequest(
            [FromRoute] int tripJoinRequestId,
            [FromBody] bool approve)
        {
            throw new NotImplementedException();
        }
    }

    public class StartDetails
    {
        public Point Location { get; set; }
        public DateTime Time { get; set; }
    }

    public class Point
    {
        decimal Latitude { get; set; }
        decimal Longtitude { get; set; }
    }
}
