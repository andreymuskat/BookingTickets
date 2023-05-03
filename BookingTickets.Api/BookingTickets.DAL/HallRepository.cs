using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class HallRepository : IHallRepository
    {
        private readonly Context _context;

        public HallRepository()
        {
            _context = new Context();
        }

        public void CreateHall(HallDto hall)
        {
            _context.Halls.Add(hall);

            _context.SaveChanges();
        }

        public void DeleteHall(int hallId)
        {
            var hall = _context.Halls.Single(i => i.Id == hallId).IsDeleted = true;

            _context.SaveChanges();
        }

        public HallDto GetHallByNumber(int hallNumber)
        {
            var searchHall = _context.Halls.SingleOrDefault(k => k.Number == hallNumber);

            return searchHall;
        }

        public HallDto GetHallById(int hallId) 
        {
            return _context.Halls.SingleOrDefault(k => k.Id == hallId)!;
        }

        public void EditHall(HallDto newHall)
        {
            var hallDb = _context.Halls
                .Where(k => k.IsDeleted == false)
                .Single(k => k.Id == newHall.Id);

            hallDb.Number = newHall.Number;
            hallDb.CinemaId = newHall.CinemaId;

            _context.SaveChanges();
        }
    }
}
