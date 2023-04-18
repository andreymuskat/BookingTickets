using System.ComponentModel.DataAnnotations;
using Core;

namespace BookingTickets.DAL.Models
{
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public UserStatus UserStatus { get; set; }

        [Required]
        public string Password { get; set; }

        public CinemaDto Cinema { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
