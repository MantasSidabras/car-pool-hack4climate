using CarPool.Trip.Application.Dto;
using CarPool.Trip.Application.Event.Queries;
using CarPool.Trip.Application.TripJoinRequest.Commands;
using CarPool.Trip.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CarPool.Trip.Web
{
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("events")]
        [ProducesResponseType(typeof(IEnumerable<EventDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Events()
            => Ok(await _mediator.Send(new GetAllEvents()));

        [HttpGet("event/trips/{eventId}")]
        [ProducesResponseType(typeof(EventDetailedDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EventTrips([FromRoute] int eventId)
            => Ok(await _mediator.Send(new GetSingleEventDetails(eventId)));

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

        [HttpPost("trip/join")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> JoinTrip(RequestToJoinTrip request)
            => Ok(await _mediator.Send(request));

        [HttpPost("trip-request/approve/{tripJoinRequestId}")]
        public async Task<IActionResult> ApproveTripRequest(
            [FromRoute] int tripJoinRequestId,
            [FromBody] bool approve)
            => Ok(await _mediator.Send(new ApproveTripJoinRequest
            {
                TripJoinRequestId = tripJoinRequestId,
                Approve = approve
            }));
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
}
