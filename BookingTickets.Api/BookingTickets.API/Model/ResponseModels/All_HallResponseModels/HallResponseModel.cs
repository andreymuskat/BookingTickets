using BookingTickets.API.Model.ResponseModels.All_CinemaResponseModels;
using BookingTickets.BLL.Models;

namespace BookingTickets.API.Model.ResponseModels.All_HallResponseModels
{
    public class HallResponseModel
    {
        public int Id { get; set; }

        public int Number { get; set; }

        public CinemaResponseModel Cinema { get; set; }

        public bool IsDeleted { get; set; }
    }
}
