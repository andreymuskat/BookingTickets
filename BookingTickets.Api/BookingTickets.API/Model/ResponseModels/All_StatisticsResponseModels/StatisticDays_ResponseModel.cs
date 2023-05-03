namespace BookingTickets.API.Model.ResponseModels.All_StatisticsResponseModels
{
    public class StatisticDays_ResponseModel
    {
        public DateTime Date { get; set; }

        public int NumbersTicketsSold { get; set; }

        public decimal SumCost { get; set; }
    }
}
