using BookingTickets.API.Controllers.Options;
using BookingTickets.BLL.Models;

namespace BookingTickets.API.Model.RequestModels
{
    public class UserRequestModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public UserStatus UserStatus { get; set; }

        public string Password { get; set; }

        public CinemaBLL CinemaId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
