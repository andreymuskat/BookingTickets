using System.ComponentModel.DataAnnotations;

namespace BookingTickets.API.Model.RequestModels.All_UserRequestModel
{
    public class UserRegisterRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
