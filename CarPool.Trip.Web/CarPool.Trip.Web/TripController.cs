﻿using CarPool.Trip.Domain.Entities;
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

        [HttpGet("trip-requests/{tripId}")]
        public TripJoinRequest GetTripRequests([FromRoute] int tripId)
        {
            throw new NotImplementedException();
        }

        [HttpPost("trip/init/{eventId}")]
        public int InitiateTrip(
            [FromRoute] int eventId, 
            [FromBody] InitTrip req)
        {
            throw new NotImplementedException();
        }

        [HttpPost("trip/join/{tripId}")]
        public TripJoinRequest JoinTrip(
            [FromRoute] int tripId,
            [FromBody] JoinTrip req)
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

    public class InitTrip
    {
        public string Address { get; set; }
        public DateTime Time { get; set; }
        public string CarPlate { get; set; }
        public string CarDescription { get; set; }
        public string DriverPhoneNumber { get; set; }
        public int Capacity { get; set; }
    }

    public class JoinTrip
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
