using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Status;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL.Models
{
    [Index(nameof(UserName), IsUnique = true)]
    public class UserDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [EnumDataType(typeof(UserStatus))]
        public UserStatus UserStatus { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey(nameof(CinemaId))]
        public virtual CinemaDto? Cinema { get; set; }

        public int? CinemaId { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
