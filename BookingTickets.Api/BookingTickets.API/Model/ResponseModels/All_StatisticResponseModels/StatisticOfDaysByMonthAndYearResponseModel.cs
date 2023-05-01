namespace BookingTickets.API.Model.ResponseModels.All_StatisticResponseModels
{
    public class StatisticOfDaysByMonthAndYearResponseModel
    {
        DateTime Date { get; set; }

        int NumbersTicketsSold { get; set; }

        decimal SumCost { get; set; }
    }
}
