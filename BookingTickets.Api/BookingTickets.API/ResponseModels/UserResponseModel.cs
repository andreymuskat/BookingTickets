namespace BookingTickets.API.Controllers.OutputModels
{
    public class UserResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public int? CinemaId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
