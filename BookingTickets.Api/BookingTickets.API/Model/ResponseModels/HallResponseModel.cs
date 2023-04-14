using BookingTickets.BLL.Models;

namespace BookingTickets.API.Model.ResponseModels
{
    public class HallResponseModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public List<SeatBLL> Seats { get; set; }

        public List<SessionBLL> Sessions { get; set; }

        public CinemaBLL Cinema { get; set; }

        public bool IsDeleted { get; set; }
    }
}
