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

        [HttpPost("trip/init")]
        public EventTrip InitiateTrip(
            [FromBody] int eventId, 
            [FromBody] decimal startLatitude, 
            [FromBody] decimal startLongtitude,
            [FromBody] DateTime tripStartTime)
        {
            throw new NotImplementedException();
        }

        [HttpPost("trip/join/{tripId}")]
        public TripJoinRequest JoinTrip(
            [FromRoute] int tripId,
            [FromBody] decimal passengerLatitude,
            [FromBody] decimal passengerLongtitude)
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
}
