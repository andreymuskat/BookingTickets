using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IHallRepository
    {
        public int CreateHall(HallDto hall);

        public void UpdateHall(HallDto hall);

        public void DeleteHall(int idHall);

        public List<SeatDto> GetAllSeatsByHallId(int idHall);
    }
}
