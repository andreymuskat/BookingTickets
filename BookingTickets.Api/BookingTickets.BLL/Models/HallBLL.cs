using BookingTickets.DAL.Models;

namespace BookingTickets.BLL.Models
{
    public class HallBLL
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public List<SeatDto> Seats { get; set; }

        public List<SessionDto> Sessions { get; set; }

        public CinemaDto Cinema { get; set; }

        public bool IsDeleted { get; set; }
    }
}
