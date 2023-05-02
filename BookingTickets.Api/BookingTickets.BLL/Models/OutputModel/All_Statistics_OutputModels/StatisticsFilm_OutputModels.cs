namespace BookingTickets.BLL.Models.OutputModel.All_Statistics_OutputModels
{
    public class StatisticsFilm_OutputModels
    {
        public int TotalAmountTickets { get; set; }

        public int PurchasedTickets { get; set; }

        public int NotPurchasedTickets { get; set; }

        public decimal BoxOfficeOnFilm { get; set; }
    }
}
