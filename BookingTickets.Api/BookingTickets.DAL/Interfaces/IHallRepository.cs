using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IHallRepository
    {
        public HallDto CreateHall(HallDto hall);
        public void UpdateHall(HallDto hall);

        public void DeleteHall(int idHall);
    }
}
