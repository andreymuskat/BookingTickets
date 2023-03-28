using BookingTickets.API.Controllers.Options;

namespace BookingTickets.API.Controllers.OutputModels
{
    public class OrderOutputModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public OrderStatus? Status { get; set; }
        public string? Code { get; set; }
        public List<SeatOutputModel> Seats { get; set; } = new();
    }
}
