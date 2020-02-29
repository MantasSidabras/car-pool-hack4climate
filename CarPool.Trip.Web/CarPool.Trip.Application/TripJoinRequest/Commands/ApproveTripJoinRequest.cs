using CarPool.Trip.Application.Exceptions;
using CarPool.Trip.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.TripJoinRequest.Commands
{
    public class ApproveTripJoinRequest : IRequest
    {
        public int TripJoinRequestId { get; set; }
        public bool Approve { get; set; }
        public int ApproverId { get; set; }

        public class Handler : IRequestHandler<ApproveTripJoinRequest>
        {
            public TripDbContext _dbContext;

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(ApproveTripJoinRequest request, CancellationToken cancellationToken)
            {
                var tripJoinRequest = _dbContext.TripJoinRequests
                    .Where(t => t.Id == request.TripJoinRequestId)
                    .Include(t => t.Trip)
                    .SingleOrDefault();

                if (tripJoinRequest == null)
                    throw new NotFoundException(nameof(TripJoinRequest), request.TripJoinRequestId);

                if (tripJoinRequest.Trip.DriverId != request.ApproverId)
                    throw new UnauthorizedException();

                tripJoinRequest.Approved = request.Approve;

                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
