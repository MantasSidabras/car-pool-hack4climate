using CarPool.Trip.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.Event.Commands
{
    public class AddEvent : IRequest<int>
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public string LogoUri { get; set; }
        public string Address { get; set; }
        public DateTime EventTime { get; set; }

        public class Handler : IRequestHandler<AddEvent, int>
        {
            private readonly TripDbContext _dbContext;
            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<int> Handle(AddEvent request, CancellationToken cancellationToken)
            {
                var ev = new Domain.Entities.Event
                {
                    Address = request.Address,
                    Description = request.Description,
                    EventName = request.EventName,
                    EventTime = request.EventTime,
                    LogoUri = request.LogoUri
                };

                _dbContext.Events.Add(ev);

                await _dbContext.SaveChangesAsync();

                return ev.Id;
            }
        }
    }
}
