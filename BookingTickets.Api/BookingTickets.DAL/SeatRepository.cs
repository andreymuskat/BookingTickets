using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
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

            var hallId = OrdersInSession[0].Seats.HallId;
            AllSeatsInHall = _context.Seats.Where(s => s.HallId == hallId).ToList();

            FreeSeats = AllSeatsInHall.Except(BookingSeats).ToList();

            return FreeSeats;
        }
        public SeatDto GetSeatById(int seatId) 
        {
            return _context.Seats
                .Single(k=> k.Id == seatId);
        }
    }
}
