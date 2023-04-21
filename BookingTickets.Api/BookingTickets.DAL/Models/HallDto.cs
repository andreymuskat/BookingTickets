using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.DAL.Models
{
    public class HallDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [ForeignKey(nameof(CinemaId))]
        public CinemaDto Cinema { get; set; }

        public int CinemaId { get; set; } 

        [Required]
        public bool IsDeleted { get; set; }
    }
}
