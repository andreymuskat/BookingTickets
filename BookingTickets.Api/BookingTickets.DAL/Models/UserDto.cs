namespace BookingTickets.DAL.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }
        public int? CinemaId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
