using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IUserRepository
    {
        UserDto AddNewUser(UserDto user);

        List<UserDto> GetAllUsers();

        List<UserDto> GetAllCashiers();
    }
}
