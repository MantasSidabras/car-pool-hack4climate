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

            public Task<IEnumerable<EventDto>> Handle(GetAllEvents request, CancellationToken cancellationToken)
            {
                return Task.FromResult(new EventDto[] {new EventDto
                {
                    Id = 1,
                    EventName = "Hack4Climate",
                    Description = "#Hack4Climate dalyvauti kviečiame IT sektoriaus profesionalus, dizainerius, viešųjų ryšių specialistus, teisininkus, architektus, inžinierius, mokytojus, studentus, moksleivius ir visus kitus, kuriuos domina ekologiškos technologijos ir tvarūs sprendimai.",
                    Address = "Gedimino pr. 16, 01103 Vilnius, Lithuania",
                    LogoUri = "https://scontent.fvno5-1.fna.fbcdn.net/v/t1.0-9/82537611_10157898834144233_5570923447380344832_o.jpg?_nc_cat=104&_nc_sid=b386c4&_nc_ohc=CeBE5E9omLcAX-UBwpW&_nc_ht=scontent.fvno5-1.fna&oh=fac56b3e335d3747ab7e8bf6dd258f2e&oe=5EFF9DD3"
                }}.AsEnumerable());
            }
        }
    }
}
