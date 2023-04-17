namespace BookingTickets.API.Model.ResponseModels
{
    public class SessionResponseModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public FilmResponseModel Film { get; set; }

        public HallResponseModel Hall { get; set; }

        public int Cost { get; set; }

        public bool IsDeleted { get; set; }
    }
}