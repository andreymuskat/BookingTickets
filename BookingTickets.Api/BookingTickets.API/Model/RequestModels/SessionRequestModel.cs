using BookingTickets.BLL.Models;

namespace BookingTickets.API.Model.RequestModels
{
    public class SessionRequestModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public FilmBLL FilmDto { get; set; }

        public int Cost { get; set; }

        public bool IsDeleted { get; set; }
    }
}
