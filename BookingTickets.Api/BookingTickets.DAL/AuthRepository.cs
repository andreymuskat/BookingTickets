using BookingTickets.DAL.Interfaces;
using Core.Status;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class AuthRepository : IAuthRepository
    {
        private readonly Context _context;

        public AuthRepository()
        {
            _context = new Context();
        }

        public int AddUser(UserDto user)
        {
            user.UserStatus = UserStatus.ClientService;
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public UserDto GetUserByName(string name)
        {
            var res = _context.Users.Single(s => s.UserName == name);
            return res;
        }
    }
}
