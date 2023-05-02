using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Model.RequestModels.All_CinemaRequestModel
{
    public class CreateAndUpdateCinemaRequestModel
    {
        [FromHeader]
        public string Name { get; set; }

        [FromHeader]
        public string Address { get; set; }
    }
}