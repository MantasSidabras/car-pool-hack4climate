using CarPool.Trip.Application.Dto;
using CarPool.Trip.Application.Exceptions;
using CarPool.Trip.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.TripJoinRequest.Queries
{
    public class GetTripDetails : IRequest<EventTripDetails>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetTripDetails, EventTripDetails>
        {
            private readonly TripDbContext _dbContext;

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<EventTripDetails> Handle(GetTripDetails request, CancellationToken cancellationToken)
            {
                var trip = _dbContext.EventTrips
                    .Where(e => e.EventId == request.Id)
                    .Include(e => e.Driver)
                    .Include(e => e.TripJoinRequests)
                    .Include(e => e.Event)
                    .AsNoTracking()
                    .SingleOrDefault();

                if (trip == null)
                    throw new NotFoundException(nameof(EventTrip), request.Id);

                var driver = new DriverDto
                {
                    Id = trip.Driver.Id,
                    CarModel = trip.Driver.CarModel,
                    Carplate = trip.Driver.Carplate,
                    Name = trip.Driver.Name,
                    Surname = trip.Driver.Surname,
                    PhoneNumber = trip.Driver.PhoneNumber
                };

                var tripJoinRequestIds = trip.TripJoinRequests.Select(x => x.Id);

                var tripJoinRequests = _dbContext.TripJoinRequests
                    .Include(x => x.Passenger)
                    .Where(x => tripJoinRequestIds.Contains(x.Id))
                    .Select(x => new TripJoinRequestDto
                    { 
                        Address = x.Address,
                        Approved = x.Approved,
                        Id = x.Id,
                        Passenger = new PassengerDto
                        {
                            Name = x.Passenger.Name,
                            PhoneNumber = x.Passenger.PhoneNumber,
                            Surname = x.Passenger.Surname
                        }
                    });

                return new EventTripDetails
                {
                    DepartureAddress = trip.Address,
                    EventAddress = trip.Event.Address,
                    DepartureTime = trip.TripStartTime,
                    Driver = driver,
                    EventName = trip.Event.EventName,
                    TripJoinRequests = tripJoinRequests
                };
            }
        }
    }
}
