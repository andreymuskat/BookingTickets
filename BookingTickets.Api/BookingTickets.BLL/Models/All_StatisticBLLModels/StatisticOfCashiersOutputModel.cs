namespace BookingTickets.BLL.Models.All_StatisticBLLModels
{
    public class StatisticOfCashiersOutputModel
    {
        public string UserName { get; set; }

        public int NumbersTicketsSold { get; set; }

        public decimal SumCost { get; set; }
    }
}
