using System;
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
                CinemaId = user.CinemaId,
            };

            _context.Users.Add(cashier);
            _context.SaveChanges();

            return _context.Users
                .Include(u => u.Cinema)
                .Single(u => u.Id == cashier.Id);
        }

        public UserDto UpdateCashier(UserDto user)
        {
            try
            {
                var cashierDb = _context.Users.Single(a => a.Id == user.Id);
                cashierDb.UserName = user.UserName;
                cashierDb.Password = user.Password;

                _context.SaveChanges();

                return _context.Users
                    .Include(u => u.Cinema)
                    .Single(u => u.Id == cashierDb.Id);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                throw new Exception($"Id:{user.Id} - отсутствует");
            }
        }

        public List<UserDto> GetAllUsers()
        {
            var result = new List<UserDto>();

            result = _context.Users
                .Where(t => !t.IsDeleted)
                .Include(u => u.Cinema)
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
                .ToList();

            return result;
        }

        public List<UserDto> GetAllCashiersByCinemaId(int cinemaId)
        {
            var result = new List<UserDto>();

            result = _context.Users
                .Where(t => t.UserStatus == Core.UserStatus.Cashier)
                .Where(t => !t.IsDeleted)
                .Where(t => t.Cinema.Id == cinemaId)
                .Include(u => u.Cinema)
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
    }
}
