using CarPool.Trip.Persistence;
using MediatR;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarPool.Trip.Application.Participant.Commands
{
    public class RegisterParticipant : IRequest<string>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Carplate { get; set; }
        public string CarModel { get; set; }

        public class Handler : IRequestHandler<RegisterParticipant, string>
        {
            private readonly TripDbContext _dbContext;
            private const string ApplicationSecret = "We Are COOL";

            public Handler(TripDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            public async Task<string> Handle(RegisterParticipant request, CancellationToken cancellationToken)
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

                return Convert.ToBase64String(
                    ProtectedData.Protect(
                        Encoding.Unicode.GetBytes(participant.PhoneNumber),
                        Encoding.Unicode.GetBytes(ApplicationSecret),
                        DataProtectionScope.LocalMachine));
            }
        }
    }
}
