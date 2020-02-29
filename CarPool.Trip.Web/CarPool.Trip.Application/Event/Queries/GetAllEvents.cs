using CarPool.Trip.Application.Dto;
using CarPool.Trip.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.Event.Queries
{
    public class GetAllEvents : IRequest<IEnumerable<EventDto>>
    {
        public GetAllEvents()
        { }

        public class Handler : IRequestHandler<GetAllEvents, IEnumerable<EventDto>>
        {
            private readonly TripDbContext _tripDb;

            public Handler(TripDbContext tripDb)
            {
                // Fake for events
                _tripDb = tripDb;
            }

            public async Task<IEnumerable<EventDto>> Handle(GetAllEvents request, CancellationToken cancellationToken)
                 => _tripDb.Events.Select(x =>
                 new EventDto
                 {
                     Id = x.Id,
                     EventName = x.EventName,
                     Description = x.Description,
                     Address = x.Address,
                     LogoUri = x.LogoUri
                 });
            
        }
    }
}
