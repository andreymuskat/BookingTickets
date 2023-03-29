using BookingTickets.API.Controllers.Options;

namespace BookingTickets.API.Controllers.OutputModels
{
    public class OrderResponseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public OrderStatus? Status { get; set; }
        public string? Code { get; set; }
        public List<SeatResponseModel> Seats { get; set; } = new();
    }
}
