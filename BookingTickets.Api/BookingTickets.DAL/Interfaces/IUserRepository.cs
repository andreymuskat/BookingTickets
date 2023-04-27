using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IUserRepository
    {
        int AddNewUser(UserDto user);

        UserDto CreateNewCashier(UserDto user);

        UserDto UpdateCashier(UserDto user);

        List<UserDto> GetAllUsers();

        List<UserDto> GetAllCashiers();

        void DeleteCashierById(int idCashier);
    }
}
