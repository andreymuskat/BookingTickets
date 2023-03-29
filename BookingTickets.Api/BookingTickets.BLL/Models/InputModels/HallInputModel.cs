namespace BookingTickets.BLL.Models.InputModels
{
    public class HallInputModel
    {
        public int Number { get; set; }
        public List<SeatDto> Seats { get; set; }
    }
}
