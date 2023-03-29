using BookingTickets.API.Controllers.Options;

namespace BookingTickets.API.Model.RequestModels
{
    public class OrderInputModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SessionId { get; set; }
        public OrderStatus? Status { get; set; }
        public string? Code { get; set; }
        public List<SeatInputModel> Seats { get; set; } = new();

    }
}
