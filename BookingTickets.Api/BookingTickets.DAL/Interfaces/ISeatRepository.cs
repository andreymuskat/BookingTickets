using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface ISeatRepository
    {
        public SeatDto CreateSeat (SeatDto seat);

        public void UpdateSeat (SeatDto seat);


    }
}
