namespace BookingTickets.BLL.Models.InputModel.All_Session_InputModel
{
    public class CreateSessionInputModel
    {
        public DateTime Date { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public decimal Cost { get; set; }
    }
}
