﻿using CarPool.Trip.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.Participant.Commands
{
    public class RegisterParticipant : IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Carplate { get; set; }
        public string CarModel { get; set; }

        public class Handler : IRequestHandler<RegisterParticipant, int>
        {
            private readonly TripDbContext _dbContext;

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<int> Handle(RegisterParticipant request, CancellationToken cancellationToken)
            {
                var participant = new Domain.Entities.Participant
                {
                    CarModel = request.CarModel,
                    Carplate = request.Carplate,
                    Name = request.Name,
                    Surname = request.Surname,
                    PhoneNumber = request.PhoneNumber
                };

                _dbContext.Participants.Add(participant);

                await _dbContext.SaveChangesAsync();

                return participant.Id;
            }
        }
    }
}
