using BookingTickets.DAL.Models;

namespace BookingTickets.BLL.Models
{
    public class SessionBLL
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public FilmDto FilmDto { get; set; }

        public int Cost { get; set; }

        public bool IsDeleted { get; set; }
    }
}
