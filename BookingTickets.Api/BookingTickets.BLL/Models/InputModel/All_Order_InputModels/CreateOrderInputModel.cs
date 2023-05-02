using Core.Status;

namespace BookingTickets.BLL.Models.InputModel.All_Order_InputModels
{
    public class CreateOrderInputModel
    {
        public int SeatsId { get; set; }

        public int UserId { get; set; }

        public int SessionId { get; set; }

        public OrderStatus Status { get; set; }

        public string? Code { get; set; }

        public DateTime Date { get; set; }

    }
}

