namespace BookingTickets.API.Model.ResponseModels
{
    public class SeatResponseModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int Row { get; set; }

        public HallResponseModel Hall { get; set; }
    }
}