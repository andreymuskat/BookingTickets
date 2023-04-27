using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IUserRepository
    {
        public UserDto AddNewUser(UserDto user);
        int AddNewUser(UserDto user);

        UserDto CreateNewCashier(UserDto user);

        List<UserDto> GetAllUsers();

        List<UserDto> GetAllCashiers();

        void DeleteCashierById(int idCashier);
    }
}
