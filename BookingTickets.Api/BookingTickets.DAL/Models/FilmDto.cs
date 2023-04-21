using System.ComponentModel.DataAnnotations;

namespace BookingTickets.DAL.Models
{
    public class FilmDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}