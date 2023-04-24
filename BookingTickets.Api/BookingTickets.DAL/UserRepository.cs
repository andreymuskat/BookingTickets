using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;

namespace BookingTickets.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository() 
        {
            _context= new Context();
        }

        public UserDto AddNewUser(UserDto user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
