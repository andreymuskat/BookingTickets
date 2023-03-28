using BookingTickets.API.Controllers.Options;

namespace BookingTickets.API.Controllers.InputModels
{
    public class OrderInputModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int SessionId { get; set; }
        public OrderStatus? Status { get; set; }
        public string? Code { get; set; }
        public List<SeatInputModel> Seats { get; set; } = new();

    }
}
