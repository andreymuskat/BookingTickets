namespace BookingTickets.BLL.Models.OutputModel.All_Sessions_OutputModels
{
    public class SessionOutputModel
    {
        public DateTime Date { get; set; }

        public int FilmId { get; set; }

        public int HallId { get; set; }

        public decimal Cost { get; set; }
    }
}
