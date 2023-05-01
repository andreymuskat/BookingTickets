using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IHallRepository
    {
        public void CreateHall(HallDto hall);

        public void DeleteHall(int hallId);

        public HallDto GetHallByNumber(int hallNumber);

        public HallDto GetHallById(int hallId);

        public void EditHall(HallDto newHall);
    }
}
