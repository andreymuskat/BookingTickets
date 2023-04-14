using BookingTickets.DAL.Models;
using Core;

namespace BookingTickets.BLL.Models
{
    public class OrderBLL
    {
        public int Id { get; set; }

        public List<SeatDto> Seats { get; set; }

        public UserDto User { get; set; }

        public SessionDto Session { get; set; }

        public OrderStatus Status { get; set; }

        public string? Code { get; set; }

        public DateTime Date { get; set; }
    }
}
