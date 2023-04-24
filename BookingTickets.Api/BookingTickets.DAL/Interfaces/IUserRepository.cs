using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IUserRepository
    {
        public UserDto AddNewUser(UserDto user);
    }
}
