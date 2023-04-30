namespace BookingTickets.BLL.Models
{
    public class SeatsForCashierOutputModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int Row { get; set; }

        public HallBLL Hall { get; set; }
    }
}
