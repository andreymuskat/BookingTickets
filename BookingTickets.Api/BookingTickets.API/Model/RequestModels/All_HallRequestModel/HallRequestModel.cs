using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Model.RequestModels.All_HallRequestModel
{
    public class HallRequestModel
    {
        [FromHeader]
        public int Number { get; set; }

        [FromHeader]
        public int CinemaId { get; set; }
    }
}
