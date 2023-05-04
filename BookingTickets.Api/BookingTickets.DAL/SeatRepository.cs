using BookingTickets.DAL.Interfaces;
using Core.Status;
using Microsoft.EntityFrameworkCore;


namespace BookingTickets.DAL
{
    public class SeatRepository : ISeatRepository
    {
        private readonly Context _context;

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

        public SeatDto GetSeatById(int seatId) 
        {
            return _context.Seats
                .SingleOrDefault(k=> k.Id == seatId)!;
        }

        public List<SeatDto> GetAllSeatInHall(int hallId)
        {
            return _context.Seats
                .Where(h => h.HallId == hallId)
                .ToList();
        }

        public List<SeatDto> GetAllSeatsBySessionId(int  sessionId)
        {
            var hallId = _context.Sessions
                .Where(k => k.IsDeleted == false)
                .Single(k => k.Id == sessionId)
                .HallId;

            var allSeats = _context.Seats
                .Where(k => k.HallId == hallId)
                .ToList();

            return allSeats;
        }

        public List<SeatDto> GetAllFreeSeatsBySessionId(int idSession)
        {
            List<SeatDto> bookingSeats = new List<SeatDto>();
            List<SeatDto> allSeatsInHall = new List<SeatDto>();
            List<SeatDto> freeSeats = new List<SeatDto>();

            var ordersInSession = _context.Orders
                .Where(s => s.SessionId == idSession)
                .Include(s => s.Seats)
                .Include(s => s.Seats.Hall)
                .ToList();

            foreach (var order in ordersInSession)
            {
                if (order.Status != OrderStatus.Canceled)
                {
                    bookingSeats.Add(order.Seats);
                }
            }

            var hallId = _context.Sessions
                .Where(s => s.IsDeleted == false)
                .Single(s => s.Id == idSession)
                .HallId;

            allSeatsInHall = _context.Seats.Where(s => s.HallId == hallId).ToList();

            freeSeats = allSeatsInHall.Except(bookingSeats).ToList();

            return freeSeats;
        }

        public List<SeatDto> GetAllPurchasedSeatsBySessionId(int idSession)
        {
            List<SeatDto> purchasedSeats = new List<SeatDto>();
            List<SeatDto> allSeatsInHall = new List<SeatDto>();

            var ordersInSession = _context.Orders
                .Where(s => s.SessionId == idSession)
                .Include(s => s.Seats)
                .Include(s => s.Seats.Hall)
                .ToList();

            foreach (var order in ordersInSession)
            {
                if (order.Status == OrderStatus.PurchasedByCashbox || order.Status == OrderStatus.PurchasedBySite)
                {
                    purchasedSeats.Add(order.Seats);
                }
            }

            return purchasedSeats;
        }
    }
}
