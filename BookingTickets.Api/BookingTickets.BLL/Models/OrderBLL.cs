using Core;

namespace BookingTickets.BLL.Models
{
    public class OrderBLL
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int SessionId { get; set; }

        public OrderStatus Status { get; set; }

        public string? Code { get; set; }

        public List<SeatDto> Seats { get; set; }
    }
}
