using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class HallRepository : IHallRepository
    {
        public int CreateHall(HallDto hall)
        {
            return hall.Id;
        }

        public void UpdateHall(HallDto hall)
        {

        }

        public void DeleteHall(int idHall)
        {

        }

        public List<SeatDto> GetAllSeatsByHallId(int idHall)
        {
            return new List<SeatDto>();
        }
    }
}
