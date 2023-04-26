using Core;
using BookingTickets.BLL.Models;

namespace BookingTickets.API.Model.ResponseModels
{
    public class OrderResponseModel
    {
        public int Id { get; set; }

        public List<SeatResponseModel> Seats { get; set; }

        public UserResponseModel User { get; set; }

        public SessionResponseModel Session { get; set; }

        public OrderStatus Status { get; set; }

        public string? Code { get; set; }

        public DateTime Date { get; set; }
    }
}
