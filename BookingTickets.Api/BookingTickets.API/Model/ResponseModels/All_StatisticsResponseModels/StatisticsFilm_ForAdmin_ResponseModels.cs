namespace BookingTickets.API.Model.ResponseModels.All_StatisticsResponseModels
{
    public class StatisticsFilm_ForAdmin_ResponseModels
    {
        public int TotalAmountTickets { get; set; }

        public int PurchasedTickets { get; set; }

        public int NotPurchasedTickets { get; set; }

        public decimal BoxOfficeOnFilm { get; set; }
    }
}
