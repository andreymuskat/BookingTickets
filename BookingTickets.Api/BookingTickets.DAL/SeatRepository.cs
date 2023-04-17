using BookingTickets.DAL.Interfaces;

namespace BookingTickets.DAL
{
    public class SeatRepository : ISeatRepository
    {
        private static Context _context;

        public SeatRepository()
        {
            _context = new Context();
        }

        public SeatDto CreateSeat(SeatDto seat)
        {
            _context.Seats.Add(seat);

            _context.SaveChanges();

            return seat;

        }

        public void UpdateSeat(SeatDto seat)
        {

        }
    }
}
