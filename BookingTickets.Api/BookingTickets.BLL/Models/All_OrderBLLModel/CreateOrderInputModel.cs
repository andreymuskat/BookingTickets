using BookingTickets.DAL.Models;
using Core;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookingTickets.BLL.Models.All_OrderBLLModel
{
    public class CreateOrderInputModel
    {
        public int SeatsId { get; set; }

        public int SessionId { get; set; }
        public int UserId { get; set; }
        public OrderStatus Status { get; set; }

        public string? Code { get; set; }
        public DateTime Date { get; set; }
    }
}

