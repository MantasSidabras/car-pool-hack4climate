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

        [HttpGet("trips")]
        public EventTrip[] Trips()
        {
            throw new NotImplementedException();
        }

        [HttpGet("trip/init")]
        public IActionResult InitiateTrip()
        {
            throw new NotImplementedException();
        }
    }
}
