using BookingTickets.BLL.Models;

namespace BookingTickets.API.Model.RequestModels.SessionRequestModel
{
    public class CreateSessionRequestModel
    {
        public DateTime Date { get; set; }

        public FilmBLL FilmDto { get; set; }

        public int Cost { get; set; }
    }
}
