using System.ComponentModel.DataAnnotations;

namespace BookingTickets.DAL.Models
{
    public class HallDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        public List<SeatDto> Seats { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
