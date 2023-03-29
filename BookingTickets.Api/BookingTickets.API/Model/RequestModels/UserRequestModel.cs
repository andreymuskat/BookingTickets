using BookingTickets.API.Controllers.Options;

namespace BookingTickets.API.Model.RequestModels
{
    public class UserRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserStatus Status { get; set; }
        public string Password { get; set; }
        public int? CinemaId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
