using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IHallRepository
    {
        void CreateHall(HallDto hall);

        void DeleteHall(int hallId);

        HallDto GetHallByNumber(int hallNumber);

        HallDto GetHallById(int hallId);

        void EditHall(HallDto newHall);
    }
}
