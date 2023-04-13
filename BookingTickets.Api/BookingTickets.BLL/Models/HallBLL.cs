namespace BookingTickets.BLL.Models
{
    public class HallBLL
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<SeatDto> Seats { get; set; }
    }
}
