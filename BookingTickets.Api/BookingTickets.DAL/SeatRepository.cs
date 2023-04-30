using BookingTickets.DAL.Interfaces;
using Core;
using Microsoft.EntityFrameworkCore;


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

        public List<SeatDto> GetAllSeatsBySessionId(int  sessionId)
        {
            var hallId = _context.Sessions
                .Single(k => k.Id == sessionId)
                .HallId;

            return _context.Seats
                .Where(k => k.HallId == hallId)
                .ToList();
        }

        public List<SeatDto> GetAllFreeSeatsBySessionId(int idSession)
        {
            List<SeatDto> BookingSeats = new List<SeatDto>();
            List<SeatDto> AllSeatsInHall = new List<SeatDto>();
            List<SeatDto> FreeSeats = new List<SeatDto>();

            var OrdersInSession = _context.Orders
                .Where(s => s.SessionId == idSession)
                .Include(s => s.Seats)
                .ToList();

            foreach (var order in OrdersInSession)
            {
                if (order.Status != OrderStatus.Canceled)
                {
                    BookingSeats.Add(order.Seats);
                }
            }

            var hallId = _context.Sessions
                .Single(s => s.Id == idSession)
                .HallId;

            AllSeatsInHall = _context.Seats.Where(s => s.HallId == hallId).ToList();

            FreeSeats = AllSeatsInHall.Except(BookingSeats).ToList();

            return FreeSeats;
        }

        public List<SeatDto> GetAllPurchasedSeatsBySessionId(int idSession)
        {
            List<SeatDto> PurchasedSeats = new List<SeatDto>();
            List<SeatDto> AllSeatsInHall = new List<SeatDto>();

            var OrdersInSession = _context.Orders
                .Where(s => s.SessionId == idSession)
                .Include(s => s.Seats)
                .ToList();

            foreach (var order in OrdersInSession)
            {
                if (order.Status == OrderStatus.PurchasedByСashbox || order.Status == OrderStatus.PurchasedBySite)
                {
                    PurchasedSeats.Add(order.Seats);
                }
            }

            return PurchasedSeats;
        }

        public List<SeatDto> GetAllSeatInHall(int hallId)
        {
            return _context.Seats
                .Where(h => h.HallId == hallId)
                .ToList();
        }
        public SeatDto GetSeatById(int seatId) 
        {
            return _context.Seats
                .Single(k=> k.Id == seatId);
        }
    }
}
