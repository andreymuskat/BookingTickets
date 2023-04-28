using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;
using BookingTickets.BLL.Models;

namespace BookingTickets.API.Model.ResponseModels.All_HallResponseModels
{
    public class HallResponseModel
    {
        public int Number { get; set; }

        public CinemaResponseModel Cinema { get; set; }
    }
}
