namespace BookingTickets.API.Model.ResponseModels.All_SessionResponseModels
{
    public class SessionResponseModelForClient
    {
        public DateTime Date { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public int Cost { get; set; }
    }
}
