using Core;
using BookingTickets.API.Model.RequestModels.All_SeatRequestModel;
using BookingTickets.API.Model.RequestModels.All_SessionRequestModel;
using BookingTickets.API.Model.RequestModels.All_UserRequestModel;

namespace BookingTickets.API.Model.RequestModels.All_OrderRequestModel
{
    public class OrderRequestModel
    {
        public int Id { get; set; }

        public List<SeatRequestModel> Seats { get; set; }

        public UserRequestModel User { get; set; }

        public SessionRequestModel Session { get; set; }

        public OrderStatus Status { get; set; }

        public string? Code { get; set; }

        public DateTime Date { get; set; }
    }
}
