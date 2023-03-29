namespace BookingTickets.DAL.Models
{
    public class CinemaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<UserDto> Employes { get; set; }
        public bool IsDeleted { get; set; }
    }
}
