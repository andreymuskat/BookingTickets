using Microsoft.AspNetCore.Mvc;

namespace BookingTickets.API.Model.RequestModels.All_SeatRequestModel
{
    public class AddSeatsRowsRequestModel
    {
        [FromHeader]
        public int SeatForBegin { get; set; }

        [FromHeader]
        public int SeatForEnd { get; set; }

        [FromHeader]
        public int NumberOfRow { get; set; }

        [FromHeader]
        public int HallId { get; set; }
    }
}