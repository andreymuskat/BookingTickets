using BookingTickets.API.Model.ResponseModels.All_HallResponseModels;

namespace BookingTickets.API.Model.ResponseModels.All_SeatResponseModels
{
    public class SeatResponseModel
    {
        public int Number { get; set; }

        public int Row { get; set; }

        public int NumderHall { get; set; }
    }
}