using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.Status;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository()
        {
            _context = new Context();
        }

        public UserDto CreateNewCashier(UserDto user)
        {
            var cashier = new UserDto
            {
                UserName = user.UserName,
                UserStatus = UserStatus.CashierService,
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
            var result = _context.Users
                .Where(t => t.UserStatus == UserStatus.CashierService)
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
                .Where(t => t.UserStatus == UserStatus.CashierService)
                .Single(i => i.Id == idCashier).UserStatus = UserStatus.ClientService;

            _context.SaveChanges();
        }

        public UserDto GetUserById(int idUser)
        {
            return _context.Users.SingleOrDefault(t => t.Id == idUser)!;
        }

        public void UpdateUserStatus(UserDto user)
        {
            var searchUser = _context.Users.SingleOrDefault(t => t.Id == user.Id);

            searchUser.UserStatus = user.UserStatus;

            _context.SaveChanges();
        }

        public void UpdateUserCinemaId(UserDto user)
        {
            var searchUser = _context.Users.SingleOrDefault(t => t.Id == user.Id);

            searchUser.CinemaId = user.CinemaId;

            _context.SaveChanges();
        }

        public UserDto GetCashierById(int idCashier)
        {
            return _context.Users
                .Where(t => t.UserStatus == UserStatus.CashierService)
                .Where(t => !t.IsDeleted)
                .SingleOrDefault(t => t.Id == idCashier)!;
        }

        public List<UserDto> GetAllCashiersByCinemaId(int cinemaId)
        {
            var result = new List<UserDto>();

            result = _context.Users
                .Where(t => t.UserStatus == UserStatus.CashierService)
                .Where(t => !t.IsDeleted)
                .Where(t => t.Cinema.Id == cinemaId)
                .Include(u => u.Cinema)
                .ToList();

            return result;
        }

        public UserDto UpdateCashier(UserDto user)
        {
            var cashierDb = _context.Users.Single(a => a.Id == user.Id);
            cashierDb.UserName = user.UserName;
            cashierDb.Password = user.Password;

            _context.SaveChanges();

            return _context.Users
                   .Include(u => u.Cinema)
                   .Single(u => u.Id == cashierDb.Id);
        }


    }
}
