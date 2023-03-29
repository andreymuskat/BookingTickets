namespace BookingTickets.BLL.Models.OutputModels
{
    public class FullHallOutputModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<SeatDto> Seats { get; set; }
    }
}
