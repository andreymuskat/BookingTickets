using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface ISeatRepository
    {
        public List<SeatDto> GetAllSeatsBySessionId(int sessionId);

        public List<SeatDto> GetAllSeatsByHallId(int idHall);

        public SeatDto CreateSeat (SeatDto seat);

        public void UpdateSeat (SeatDto seat);
    }
}
