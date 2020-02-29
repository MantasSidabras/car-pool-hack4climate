using CarPool.Trip.Application.Dto;
using CarPool.Trip.Application.Exceptions;
using CarPool.Trip.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.Participant.Queries
{
    public class GetParticipant : IRequest<ParticipantDto>
    {
        public int UserId { get; set; }

        public class Handler : IRequestHandler<GetParticipant, ParticipantDto>
        {
            private readonly TripDbContext _dbContext;

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<ParticipantDto> Handle(GetParticipant req, CancellationToken cancellationToken)
            {
                var part =  _dbContext.Participants
                    .Where(x => x.Id == req.UserId)
                    .FirstOrDefault();

                if (part == null)
                    throw new NotFoundException("User", req.UserId);

                return new ParticipantDto
                {
                    CarModel = part.CarModel,
                    Carplate = part.Carplate,
                    Id = part.Id,
                    Name = part.Name,
                    PhoneNumber = part.PhoneNumber,
                    Surname = part.Surname
                };
            }
        }
    }
}
