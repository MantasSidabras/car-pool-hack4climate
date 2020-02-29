using CarPool.Trip.Application.Dto;
using CarPool.Trip.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.Participant.Queries
{
    public class GetParticipants : IRequest<IEnumerable<ParticipantDto>>
    {
        public class Handler : IRequestHandler<GetParticipants, IEnumerable<ParticipantDto>>
        {
            private readonly TripDbContext _dbContext;

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<IEnumerable<ParticipantDto>> Handle(GetParticipants request, CancellationToken cancellationToken)
            {
                return _dbContext.Participants
                    .Select(x => new ParticipantDto
                    {
                        CarModel = x.CarModel,
                        Carplate = x.Carplate,
                        Id = x.Id,
                        Name = x.Name,
                        PhoneNumber = x.PhoneNumber,
                        Surname = x.Surname
                    });
            }
        }
    }
}
