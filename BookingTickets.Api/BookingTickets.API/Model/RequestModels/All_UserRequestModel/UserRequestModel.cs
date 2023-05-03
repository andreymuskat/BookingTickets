using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;
using Core.Status;

namespace BookingTickets.API.Model.RequestModels.All_UserRequestModel
{
    public class UserRequestModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public UserStatus UserStatus { get; set; }

        public string Password { get; set; }

        public CinemaRequestModel CinemaId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
