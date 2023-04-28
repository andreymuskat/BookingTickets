using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class HallRepository : IHallRepository
    {
        private static Context _context;

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
    }
}
