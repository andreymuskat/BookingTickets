using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Model.RequestModels.All_UserRequestModel
{
    public class UpdateCashierRequestModel
    {
        [FromHeader]
        public string UserName { get; set; }

        [FromHeader]
        public string Password { get; set; }
    }
}
