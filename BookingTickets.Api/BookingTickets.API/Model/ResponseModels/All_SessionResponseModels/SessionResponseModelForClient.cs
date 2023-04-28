using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_HallResponseModels;

namespace BookingTickets.API.Model.ResponseModels.All_SessionResponseModels
{
    public class SessionResponseModelForClient
    {
        public DateTime Date { get; set; }

        public FilmResponseModelForClient Film { get; set; }

        public HallResponseModelForClient Hall { get; set; }

        public int Cost { get; set; }
    }
}
