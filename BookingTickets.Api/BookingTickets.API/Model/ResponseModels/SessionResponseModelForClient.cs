namespace BookingTickets.API.Model.ResponseModels
{
    public class SessionResponseModelForClient
    {
        public DateTime Date { get; set; }

        public FilmResponseModelForClient Film { get; set; }

        public HallResponseModelForClient Hall { get; set; }

        public int Cost { get; set; }
    }
}
