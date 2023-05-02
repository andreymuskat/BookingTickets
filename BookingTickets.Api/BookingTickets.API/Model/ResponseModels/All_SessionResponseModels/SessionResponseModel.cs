using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_HallResponseModels;

namespace BookingTickets.API.Model.ResponseModels.All_SessionResponseModels
{
    public class SessionResponseModel
    {
        public DateTime Date { get; set; }

        public FilmResponseModel Film { get; set; }

        public int Cost { get; set; }
    }
}