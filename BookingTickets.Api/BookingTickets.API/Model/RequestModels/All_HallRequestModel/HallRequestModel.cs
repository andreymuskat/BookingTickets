using BookingTickets.API.Model.RequestModels.All_CinemaRequestModel;

namespace BookingTickets.API.Model.RequestModels.All_HallRequestModel
{
    public class HallRequestModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public CinemaRequestModel Cinema { get; set; }

        public bool IsDeleted { get; set; }
    }
}
