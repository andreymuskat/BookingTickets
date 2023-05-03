using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_HallResponseModels;

namespace BookingTickets.API.Model.ResponseModels.All_SessionResponseModels
{
    public class SessionForCashierResponseModel
    {
        public DateTime Date { get; set; }

        public FilmResponseModel Film { get; set; }

        public HallResponseModel Hall { get; set; }

        public decimal Cost { get; set; }
    }
}
