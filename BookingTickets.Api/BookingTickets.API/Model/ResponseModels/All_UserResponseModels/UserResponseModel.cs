using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;
using Core.Status;

namespace BookingTickets.API.Model.ResponseModels.All_UserResponseModels
{
    public class UserResponseModel
    {
        public string UserName { get; set; }

        public UserStatus UserStatus { get; set; }

        public string Password { get; set; }

        public CinemaResponseModel Cinema { get; set; }
    }
}