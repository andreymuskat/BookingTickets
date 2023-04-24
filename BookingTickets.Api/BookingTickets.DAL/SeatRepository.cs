using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

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

        public List<SeatDto> GetAllSeatsByHallId(int idHall)
        {
            return new List<SeatDto>();
        }

        public List<SeatDto> GetAllSeatsBySessionId(int sessionId)
        {
            return new List<SeatDto>();
        }
        public int GetSeatIdByNumberAndRow(int row, int number)
        {
            var seat = _context.Seats.Find(row, number);
            int seatId =seat.Id;
            return seatId;
        }

        public void AddRowToHall(int hallId, int seatForBegin, int seatForEnd, int numberOfRow)
        {

                _context.SaveChanges();
        }

        //_____________

        public List<SeatDto> GetFreeSeatsBySessionInHisCinema(SessionDto session)
        {
            return new List<SeatDto>();
        }
    }
}
