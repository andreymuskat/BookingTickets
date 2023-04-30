using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IUserRepository
    {
        int AddNewUser(UserDto user);

        UserDto CreateNewCashier(UserDto user);

        List<UserDto> GetAllUsers();

        List<UserDto> GetAllCashiers();

        void DeleteCashierById(int idCashier);

        public UserDto GetUserById(int idUser);

        public void UpdateUserStatus(UserDto user);
    }
}
