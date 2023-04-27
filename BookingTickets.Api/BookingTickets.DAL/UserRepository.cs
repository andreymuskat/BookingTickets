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

        public UserDto CreateNewCashier(UserDto user)
        {
            var cashier = new UserDto
            {
                UserName = user.UserName,
                UserStatus = Core.UserStatus.Cashier,
                Password = user.Password,
                CinemaId = 1,
            };

            _context.Users.Add(cashier);
            _context.SaveChanges();

            return _context.Users
                .Include(u => u.Cinema)
                .Single(u => u.Id == cashier.Id);
        }

        public List<UserDto> GetAllUsers()
        {
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
                .Where(t => !t.IsDeleted)
                .Include(u => u.Cinema)
                .AsNoTracking()
                .ToList();

            return result;
        }

        public int AddNewUser(UserDto user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public void DeleteCashierById(int idCashier)
        {
            var cash = _context.Users
                .Where(t => t.UserStatus == Core.UserStatus.Cashier)
                .Single(i => i.Id == idCashier).IsDeleted = true;

            _context.SaveChanges();
        }

        public int GetUserCinemaId(UserDto user)
        {
            return user.CinemaId;
        }
    }
}
