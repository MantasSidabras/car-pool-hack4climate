using CarPool.Trip.Application.Exceptions;
using CarPool.Trip.Persistence;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.Participant.Commands
{
    public class UpdateParticipant : IRequest
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Carplate { get; set; }
        public string CarModel { get; set; }

        public class Handler : IRequestHandler<UpdateParticipant>
        {
            private readonly TripDbContext _dbContext;

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<Unit> Handle(UpdateParticipant request, CancellationToken cancellationToken)
            {
                var participant = _dbContext.Participants
                    .Where(p => p.Id == request.Id)
                    .SingleOrDefault();

                if (participant == null)
                    throw new NotFoundException(nameof(Participant), request.Id);

                participant.PhoneNumber = request.PhoneNumber;
                participant.CarModel = request.CarModel;
                participant.Carplate = request.Carplate;

                await _dbContext.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}
