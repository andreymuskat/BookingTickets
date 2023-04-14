using System.ComponentModel.DataAnnotations;
using Core;

namespace BookingTickets.DAL.Models
{
    public class OrderDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public List<SeatDto> Seats { get; set; }

        [Required]
        public UserDto User { get; set; }

        [Required]
        public SessionDto Session { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public string? Code { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
