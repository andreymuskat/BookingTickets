namespace BookingTickets.API.Model.RequestModels.All_SessionRequestModel
{
    public class CreateSessionRequestModel
    {
        public DateTime Date { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public decimal Cost { get; set; }
    }
}
