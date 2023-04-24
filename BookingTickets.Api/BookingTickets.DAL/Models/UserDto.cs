using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [EnumDataType(typeof(UserStatus))]
        public UserStatus UserStatus { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey(nameof(CinemaId))]
        public CinemaDto Cinema { get; set; }

        public int CinemaId { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
