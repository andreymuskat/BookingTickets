using BookingTickets.API.Controllers.Options;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public OrderStatus? Status { get; set; }
        public string? Code { get; set; }
        public List<SeatDto> Seats { get; set; } = new();
    }
}
