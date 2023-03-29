namespace BookingTickets.DAL.Models
{
    public class HallDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<SeatDto> Seats { get; set; }
        public bool IsDeleted { get; set; }
    }
}
