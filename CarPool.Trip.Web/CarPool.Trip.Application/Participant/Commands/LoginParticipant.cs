using CarPool.Trip.Application.Dto;
using CarPool.Trip.Persistence;
using MediatR;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarPool.Trip.Application.Exceptions;

namespace CarPool.Trip.Application.Participant.Commands
{
    public class LoginParticipant : IRequest<ParticipantDto>
    {
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public class Handler : IRequestHandler<LoginParticipant, ParticipantDto>
        {
            private readonly TripDbContext _dbContext;
            private const string ApplicationSecret = "We Are COOL";

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ParticipantDto> Handle(LoginParticipant request, CancellationToken cancellationToken)
            {
                var participant = _dbContext.Participants.Where(t => t.PhoneNumber == request.PhoneNumber).SingleOrDefault();

                if (participant == null)
                    throw new NotFoundException(nameof(TripJoinRequest), request.PhoneNumber);

                if (!participant.Password.Equals(request.Password))
                    throw new UnauthorizedException();

                return new ParticipantDto
                {
                    Id = participant.Id,
                    CarModel = participant.CarModel,
                    Carplate = participant.Carplate,
                    Name = participant.Name,
                    PhoneNumber = participant.PhoneNumber,
                    Surname = participant.Surname
                };
            }
        }
    }
}
