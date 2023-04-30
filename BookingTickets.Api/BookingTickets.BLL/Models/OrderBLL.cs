using Core;

namespace BookingTickets.BLL.Models
{
    public class OrderBLL
    {
        public SeatBLL Seats { get; set; }

        public UserBLL User { get; set; }

        public SessionBLL Session { get; set; }

        public OrderStatus Status { get; set; }

        public string? Code { get; set; }

        public DateTime Date { get; set; }
    }
}
