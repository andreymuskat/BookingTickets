using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IHallRepository
    {
        public HallDto CreateHall(HallDto hall);
    }
}
