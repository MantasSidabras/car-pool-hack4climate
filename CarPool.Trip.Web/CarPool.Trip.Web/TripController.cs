using CarPool.Trip.Application.Dto;
using CarPool.Trip.Application.Encryption;
using CarPool.Trip.Application.Event.Commands;
using CarPool.Trip.Application.Event.Queries;
using CarPool.Trip.Application.EventTrip.Commands;
using CarPool.Trip.Application.Exceptions;
using CarPool.Trip.Application.Participant.Commands;
using CarPool.Trip.Application.Participant.Queries;
using CarPool.Trip.Application.TripJoinRequest.Commands;
using CarPool.Trip.Application.TripJoinRequest.Queries;
using CarPool.Trip.Domain.Entities;
using CarPool.Trip.Persistence;
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
        private readonly IEncryptor _encryptor;
        private readonly TripDbContext _dbContext;

        public TripController(IMediator mediator, IEncryptor encryptor, TripDbContext dbContext)
        {
            _mediator = mediator;
            _encryptor = encryptor;
            _dbContext = dbContext;
        }

        [HttpGet("events")]
        [ProducesResponseType(typeof(IEnumerable<EventDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Events()
        {
            return Ok(await _mediator.Send(new GetAllEvents()));
        }

        [HttpPost("event")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddEvent(AddEvent addEventCommand) =>
            Ok(await _mediator.Send(addEventCommand));
        

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
        [ProducesResponseType(typeof(ParticipantDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Register(RegisterParticipant request)
        {
            var participant = await _mediator.Send(request);
            participant.AuthToken = _encryptor.EncryptData(participant.Id);
            return Ok(participant);
        }

        [HttpGet("participant")]
        [ProducesResponseType(typeof(ParticipantDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetParticipant() =>
            Ok(await _mediator.Send(new GetParticipant { UserId = GetUserId() }));

        [HttpPost("participant/login")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ParticipantDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Login(LoginParticipant request)
        {
            var participant = await _mediator.Send(request);
            participant.AuthToken = _encryptor.EncryptData(participant.Id);
            return Ok(participant);
        }

        [HttpGet("trip/{id}")]
        [ProducesResponseType(typeof(EventTripDetails), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> TripDetails(int id) =>
            Ok(await _mediator.Send(new GetTripDetails { Id = id }));

        [HttpPost("trip/init")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> InitiateTrip(InitiateEventTrip request)
        {
            request.DriverId = GetUserId();
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("trip/join")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> JoinTrip(RequestToJoinTrip request)
        {
            var userId = GetUserId();
            request.PassengerId = userId;
            return Ok(await _mediator.Send(request));
        }

        [HttpPost("trip-request/approve/{tripJoinRequestId}")]
        public async Task<IActionResult> ApproveTripRequest(
            [FromRoute] int tripJoinRequestId, [FromBody] bool approve)
        {
            var userId = GetUserId();
            return Ok(await _mediator.Send(new ApproveTripJoinRequest
                {
                    TripJoinRequestId = tripJoinRequestId,
                    Approve = approve,
                    ApproverId = userId
                }));
        }

        private int GetUserId()
        {
            try
            {
                var authHeader = HttpContext.Request.Headers["Authorization"][0].Split(' ')[1];

                if (string.IsNullOrEmpty(authHeader))
                    throw new UnauthorizedException();

                return _encryptor.DecryptData(authHeader);
            }
            catch
            {
                throw new UnauthorizedException();
            }
        }
    }
}
