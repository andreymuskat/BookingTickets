using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface ISeatRepository
    {
        public void CreateSeat (SeatDto seat);

        public void UpdateSeat (SeatDto seat);
    }
}
