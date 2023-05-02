namespace BookingTickets.BLL.Models.OutputModel.All_Seats_OutputModels
{
    public class SeatsForCashierOutputModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public int Row { get; set; }

        public HallBLL Hall { get; set; }
    }
}
