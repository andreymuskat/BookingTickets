using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IAuthRepository
    {
        int AddUser(UserDto user);
    }
}

