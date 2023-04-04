using System.ComponentModel.DataAnnotations;
using Core;

namespace BookingTickets.DAL.Models
{
    public class OrderDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int SessionId { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        public string? Code { get; set; }

        [Required]
        public List<SeatDto> Seats { get; set; }
    }
}
