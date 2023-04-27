namespace BookingTickets.BLL.Models.All_SessionBLLModel
{
    public class CreateSessionInputModel
    {
        public DateTime Date { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public decimal Cost { get; set; }
    }
}
