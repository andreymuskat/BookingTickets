namespace BookingTickets.API.Model.RequestModels.All_SeatRequestModel
{
    public class AddSeatsRowsRequestModel
    { 
        public int SeatForBegin { get; set; }

        public int SeatForEnd { get; set; }

        public int NumberOfRow { get; set; }

        public int HallId { get; set; }
    }
}