namespace BookingTickets.API.Model.ResponseModels.All_SessionResponseModels
{
    public class SessionResponseModel
    {
        public DateTime Date { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public decimal Cost { get; set; }
    }
}
