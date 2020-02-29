using CarPool.Trip.Application.Dto;
using CarPool.Trip.Application.Exceptions;
using CarPool.Trip.Persistence;
using System.Linq;

namespace CarPool.Trip.Application.Participant.Queries
{
    public class ParticipantGet
    {
        private readonly TripDbContext _dbContext;

        public ParticipantGet(TripDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ParticipantDto Handle(int userId)
        {
            var part = _dbContext.Participants
                .Where(x => x.Id == userId)
                .FirstOrDefault();

            if (part == null)
                throw new NotFoundException("User", userId);

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
