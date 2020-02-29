using CarPool.Trip.Application.Exceptions;
using CarPool.Trip.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.EventTrip.Commands
{
    public class InitiateEventTrip : IRequest<int>
    {
        public int EventId { get; set; }
        public int DriverId { get; set; }
        public string FromAddress { get; set; }
        public DateTime DepartureTime { get; set; }
        public int Capacity { get; set; }

        public class Handler : IRequestHandler<InitiateEventTrip, int>
        {
            private TripDbContext _dbContext;

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<int> Handle(InitiateEventTrip request, CancellationToken cancellationToken)
            {
                var ev = _dbContext.Events
                    .Where(e => e.Id == request.EventId)
                    .SingleOrDefault();

                if (ev == null)
                    throw new NotFoundException(nameof(Event), request.EventId);

                var driver = _dbContext.Participants
                    .Where(p => p.Id == request.DriverId)
                    .SingleOrDefault();

                if (driver == null)
                    throw new NotFoundException("Driver", request.DriverId);

                var eventTrip = new Domain.Entities.EventTrip
                {
                    Address = request.FromAddress,
                    Capacity = request.Capacity,
                    Event = ev,
                    TripStartTime = request.DepartureTime,
                    Driver = driver
                };

                _dbContext.EventTrips.Add(eventTrip);

                await _dbContext.SaveChangesAsync();

                return eventTrip.Id;
            }
        }
    }
}
