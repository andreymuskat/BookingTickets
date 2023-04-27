namespace BookingTickets.BLL.Models
{
    public class SessionBLL
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public FilmBLL Film { get; set; }

        public HallBLL Hall { get; set; }

        public decimal Cost { get; set; }

        public bool IsDeleted { get; set; }
    }
}
