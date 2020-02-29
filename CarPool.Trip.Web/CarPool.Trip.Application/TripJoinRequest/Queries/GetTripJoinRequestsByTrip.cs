using CarPool.Trip.Application.Dto;
using CarPool.Trip.Application.Exceptions;
using CarPool.Trip.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.TripJoinRequest.Queries
{
    public class GetTripJoinRequestsByTrip : IRequest<IEnumerable<TripJoinRequestDto>>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetTripJoinRequestsByTrip, IEnumerable<TripJoinRequestDto>>
        {
            private TripDbContext _dbContext;

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<IEnumerable<TripJoinRequestDto>> Handle(GetTripJoinRequestsByTrip request, CancellationToken cancellationToken)
            {
                var trip = _dbContext.EventTrips
                    .Where(e => e.Id == request.Id)
                    .Include(e => e.TripJoinRequests)
                    .SingleOrDefault();

                if (trip == null)
                    new NotFoundException(nameof(EventTrip), request.Id);

                var tripJoinRequestIds = trip.TripJoinRequests.Select(x => x.Id);

                return _dbContext.TripJoinRequests
                    .Where(t => tripJoinRequestIds.Contains(t.Id))
                    .Include(t => t.Passenger)
                    .Select(t => new TripJoinRequestDto
                    {
                        Address = t.Address,
                        Approved = t.Approved,
                        Id = t.Id,
                        Passenger = new PassengerDto
                        {
                            Name = t.Passenger.Name,
                            PhoneNumber = t.Passenger.PhoneNumber,
                            Surname = t.Passenger.Surname
                        }
                    });
            }
        }
    }
}
