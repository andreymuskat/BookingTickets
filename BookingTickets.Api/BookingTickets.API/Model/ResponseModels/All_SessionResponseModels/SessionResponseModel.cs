using BookingTickets.API.Model.ResponseModels.All_FilmResponseModels;
using BookingTickets.API.Model.ResponseModels.All_HallResponseModels;

namespace BookingTickets.API.Model.ResponseModels.All_SessionResponseModels
{
    public class SessionResponseModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public FilmResponseModel Film { get; set; }

        public HallResponseModel Hall { get; set; }

        public int Cost { get; set; }

        public bool IsDeleted { get; set; }
    }
}