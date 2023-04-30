namespace BookingTickets.API.Model.ResponseModels.All_SessionResponseModels
{
    public class SessionForCashierResponseModel
    {
        public DateTime Date { get; set; }

        public string NameFilm { get; set; }

        public int Duration { get; set; }

        public int NumberHall { get; set; }

        public decimal Cost { get; set; }
    }
}
