namespace CarPool.Trip.Application.Dto
{
    public class ParticipantDto
    {
        public string AuthToken { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Carplate { get; set; }
        public string CarModel { get; set; }
    }
}
