namespace BookingTickets.API.Model.ResponseModels.All_StatisticResponseModels
{
    public class StatisticOfDaysByMonthAndYearResponseModel
    {
        public DateTime Date { get; set; }

        public int NumbersTicketsSold { get; set; }

        public decimal SumCost { get; set; }
    }
}
