namespace BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels
{
    public class StatisticDays_OutputModel
    {
        public DateTime Date { get; set; }

        public int NumbersTicketsSold { get; set; }

        public decimal SumCost { get; set; }
    }
}
