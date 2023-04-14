using BookingTickets.API.Controllers.Options;
using BookingTickets.BLL.Models;

namespace BookingTickets.API.Model.ResponseModels
{
    public class OrderResponseModel
    {
        public int Id { get; set; }

        public List<SeatBLL> Seats { get; set; }

        public UserBLL UserId { get; set; }

        public SessionBLL SessionId { get; set; }

        public OrderStatus? Status { get; set; }

        public string? Code { get; set; }

        public DateTime Date { get; set; }
    }
}
