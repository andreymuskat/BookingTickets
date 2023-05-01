namespace BookingTickets.BLL.Models.All_StatisticBLLModels
{
    public class StatisticOfDaysOutputModel
    {
        public DateTime Date { get; set; }

        public int NumbersTicketsSold { get; set; }

        public decimal SumCost { get; set; }
    }
}
