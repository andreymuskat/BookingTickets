using BookingTickets.API.Model.RequestModels.All_HallRequestModel;

namespace BookingTickets.API.Model.RequestModels.All_SeatRequestModel
{
    public class SeatRequestModel
    {
        public int Number { get; set; }

        public int Row { get; set; }

        public HallRequestModel Hall { get; set; }
    }
}