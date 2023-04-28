using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;

namespace BookingTickets.API.Model.ResponseModels.All_HallResponseModels
{
    public class HallResponseModelForClient : HallResponseModel
    {
        public CinemaResponseModel Cinema { get; set; }
    }
}
