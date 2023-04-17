using BookingTickets.API.Model.RequestModels.All_FilmRequestModel;
using BookingTickets.API.Model.RequestModels.All_HallRequestModel;

namespace BookingTickets.API.Model.RequestModels.All_SessionRequestModel
{
    public class SessionRequestModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public FilmRequestModel Film { get; set; }

        public HallRequestModel Hall { get; set; }

        public int Cost { get; set; }

        public bool IsDeleted { get; set; }
    }
}
