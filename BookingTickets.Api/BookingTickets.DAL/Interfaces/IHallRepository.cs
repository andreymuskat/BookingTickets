using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IHallRepository
    {
        public HallDto CreateHall(HallDto hall);
        public void AddRowToHall(int idHall, int seatForBegin, int seatForEnd, int amountOfRows);
        public void UpdateHall(HallDto hall);

        public void DeleteHall(int idHall);
    }
}
