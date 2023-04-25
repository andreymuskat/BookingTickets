using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class UserRepository : IUserRepository
    {
        private static Context _context;

        public UserRepository()
        {
            _context = new Context();
        }

        public UserDto AddNewUser(UserDto user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public List<UserDto> GetAllUsers()
        {
            //return _context.Users.Where(t => !t.IsDeleted).ToList();
            var result = new List<UserDto>();

            result = _context.Users
                .Where(t => !t.IsDeleted)
                .Include(u => u.Cinema)
                .AsNoTracking()
                .ToList();

            return result;
        }

        public List<UserDto> GetAllCashiers()
        {

            var result = new List<UserDto>();

            result = _context.Users
                .Where(t => t.UserStatus == Core.UserStatus.Cashier)
                .Include(u => u.Cinema)
                .AsNoTracking()
                .ToList();

            return result;
        }
    }
}
