using System.ComponentModel.DataAnnotations;

namespace BookingTickets.API.Model.RequestModels.All_UserRequestModel
{
    public class UserLoginRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
