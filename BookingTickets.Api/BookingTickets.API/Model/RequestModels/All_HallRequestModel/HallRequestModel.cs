using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;

namespace BookingTickets.API.Model.RequestModels.All_HallRequestModel
{
    public class HallRequestModel
    {
        public int Number { get; set; }

        public int CinemaId { get; set; }
    }
}
