using CarPool.Trip.Application.Dto;
using CarPool.Trip.Application.Exceptions;
using CarPool.Trip.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.Event.Queries
{
    public class GetSingleEventDetails : IRequest<EventDetailedDto>
    {
        public int Id { get; }
        public GetSingleEventDetails(int id)
        {
            Id = id;
        }

        public class Handler : IRequestHandler<GetSingleEventDetails, EventDetailedDto>
        {
            private readonly TripDbContext _dbContext;

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<EventDetailedDto> Handle(GetSingleEventDetails request, CancellationToken cancellationToken)
            {
                var e = _dbContext.Events
                    .Include(e => e.EventTrips)
                    .Where(x => x.Id == request.Id)
                    .SingleOrDefault();

                if (e == null)
                    throw new NotFoundException(nameof(Event), request.Id);

                var eventTrips = _dbContext.EventTrips
                    .Where(et => et.EventId == request.Id)
                    .Include(et => et.Driver)
                    .Include(et => et.TripJoinRequests);

                return new EventDetailedDto
                {
                    Id = e.Id,
                    Address = e.Address,
                    Description = e.Description,
                    EventName = e.EventName,
                    LogoUri = e.LogoUri,
                    EventTrips = eventTrips.Select(x =>
                        new EventDetailedDto.EventTripDto 
                        {
                            Address = x.Address,
                            Capacity = x.Capacity,
                            CarModel = x.Driver.CarModel,
                            DriverName = $"{x.Driver.Name} {x.Driver.Surname}",
                            CurrentPassengerCount = x.TripJoinRequests
                                .Where(t => t.Approved.HasValue && t.Approved.Value)
                                .Count()
                        })
                };
            }
        }
    }
}
