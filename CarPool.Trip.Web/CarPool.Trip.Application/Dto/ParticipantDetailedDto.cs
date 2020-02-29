using System;
using System.Collections.Generic;
using System.Text;

namespace CarPool.Trip.Application.Dto
{
    public class ParticipantDetailedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Carplate { get; set; }
        public string CarModel { get; set; }
        public string Password { get; set; }
    }
}
