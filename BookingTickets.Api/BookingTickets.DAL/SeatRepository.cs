using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
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

        public List<SeatDto> GetAllFreeSeats(int idSession)
        {
            List<SeatDto> seatDtos = new List<SeatDto>();
            List<SeatDto> seatsInHall = new List<SeatDto>();
            var listOrders = _context.Orders.Where(s => s.Id == idSession);

            foreach (var order in listOrders)
            {
                seatDtos.Add(order.Seats);
            }

            var listOrders2 = _context.Orders
                .Include(s=>s.Session)
                .ThenInclude(s => s.Hall)
                .Include(o=>o.Seats)
                .ToList()
                .FindAll(o => o.SessionId == idSession).ToList();           

            foreach (var order in listOrders2)
            {
                seatsInHall.Add(order.Seats);
            }

            List<SeatDto> freeSeats = seatsInHall.Except(seatDtos).ToList();

            return freeSeats;
        }
    } 
}