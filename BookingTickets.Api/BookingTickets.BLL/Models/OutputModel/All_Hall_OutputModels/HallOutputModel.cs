using BookingTickets.BLL.Models.OutputModel.All_Cinema_OutputModels;

namespace BookingTickets.BLL.Models.OutputModel.All_Hall_OutputModels
{
    public class HallOutputModel
    {
        public int Number { get; set; }

        public CinemaOutputModel Cinema { get; set; }
    }
}
