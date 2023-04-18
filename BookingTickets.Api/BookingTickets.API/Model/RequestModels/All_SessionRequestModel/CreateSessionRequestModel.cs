using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_HallRequestModel;

namespace BookingTickets.API.Model.RequestModels.All_SessionRequestModel
{
    public class CreateSessionRequestModel
    {
        public DateTime Date { get; set; }

        public string Film { get; set; }

        public int Hall { get; set; }

        public int Cost { get; set; }
    }
}
