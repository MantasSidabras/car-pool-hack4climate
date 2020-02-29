using CarPool.Trip.Application.Exceptions;
using CarPool.Trip.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.TripJoinRequest.Commands
{
    public class RequestToJoinTrip : IRequest
    {
        public int PassengerId { get; set; }
        public int TripId { get; set; }
        public string PickUpAddress { get; set; }

        public class Handler : IRequestHandler<RequestToJoinTrip>
        {
            private readonly TripDbContext _dbContext;

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(RequestToJoinTrip request, CancellationToken cancellationToken)
            {
                var passenger = _dbContext.Participants
                    .Where(p => p.Id == request.PassengerId)
                    .SingleOrDefault();

                if (passenger == null)
                    throw new NotFoundException("Passenger", request.PassengerId);

                var trip = _dbContext.EventTrips
                    .Where(e => e.Id == request.TripId)
                    .SingleOrDefault();

                if (trip == null)
                    throw new NotFoundException(nameof(Trip), request.TripId);

                var tripJoinRequest = new Domain.Entities.TripJoinRequest
                {
                    Address = request.PickUpAddress,
                    Approved = null,
                    Trip = trip,
                    Passenger = passenger
                };

                _dbContext.TripJoinRequests.Add(tripJoinRequest);

                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
