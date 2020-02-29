using CarPool.Trip.Application.Dto;
using CarPool.Trip.Application.Event.Queries;
using CarPool.Trip.Application.EventTrip.Commands;
using CarPool.Trip.Application.Participant.Commands;
using CarPool.Trip.Application.TripJoinRequest.Commands;
using CarPool.Trip.Application.TripJoinRequest.Queries;
using CarPool.Trip.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("event/{eventId}")]
        [ProducesResponseType(typeof(EventDetailedDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> EventTrips([FromRoute] int eventId)
            => Ok(await _mediator.Send(new GetSingleEventDetails(eventId)));

        [HttpGet("trip-requests/{tripId}")]
        [ProducesResponseType(typeof(TripJoinRequestDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetTripRequests([FromRoute] int tripId)
            => Ok(await _mediator.Send(new GetTripJoinRequestsByTrip { Id = tripId }));

        [HttpPost("participant/register")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Register(RegisterParticipant request)
            => Ok(await _mediator.Send(request));

        [HttpPost("participant/login")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ParticipantDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Login(LoginParticipant request)
            => Ok(await _mediator.Send(request));

        [HttpGet("trip/{id}")]
        [ProducesResponseType(typeof(EventTripDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> TripDetails(int id) =>
            Ok(await _mediator.Send(new GetTripDetails { Id = id }));

        [HttpPost("trip/init")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> InitiateTrip(InitiateEventTrip request) =>
            Ok(await _mediator.Send(request));

        [HttpPost("trip/join")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> JoinTrip(RequestToJoinTrip request)
            => Ok(await _mediator.Send(request));

        [HttpPost("trip-request/approve/{tripJoinRequestId}")]
        public async Task<IActionResult> ApproveTripRequest(
            [FromRoute] int tripJoinRequestId, [FromBody] bool approve)
            => Ok(await _mediator.Send(new ApproveTripJoinRequest
            {
                TripJoinRequestId = tripJoinRequestId,
                Approve = approve
            }));
    }
}
