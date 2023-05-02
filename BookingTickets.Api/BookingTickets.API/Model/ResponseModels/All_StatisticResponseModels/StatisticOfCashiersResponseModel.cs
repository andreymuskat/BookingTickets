namespace BookingTickets.API.Model.ResponseModels.All_StatisticResponseModels
{
    public class StatisticOfCashiersResponseModel
    {
        public string UserName { get; set; }

        public int NumbersTicketsSold { get; set; }

        public decimal SumCost { get; set; }

    }
}
