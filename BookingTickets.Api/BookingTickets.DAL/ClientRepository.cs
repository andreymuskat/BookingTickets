using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTickets.DAL
{
    public class UserRepository: IUserRepository
    {
        private static Context _context;

        public UserDto AddNewUser(UserDto userDto)
        {
            _context.Users.Add(userDto);

            _context.SaveChanges();

            return new UserDto();
        }
    }
}
