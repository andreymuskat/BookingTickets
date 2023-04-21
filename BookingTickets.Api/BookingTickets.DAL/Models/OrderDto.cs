using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core;

namespace BookingTickets.DAL.Models
{
    public class OrderDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(SeatId))]
        public List<SeatDto> Seats { get; set; }

        public int SeatId { get; set; }

        [Required]
        [ForeignKey(nameof(UserId))]
        public UserDto User { get; set; }

        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(SessionId))]
        public SessionDto Session { get; set; }

        public int SessionId { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string? Code { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
