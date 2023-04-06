using BookingTickets.DAL.Interfaces;

namespace BookingTickets.DAL
{
    public class SeatRepository : ISeatRepository
    {
        private static Context _context;

        public SeatRepository(Context context)
        {
            _context = context;
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
