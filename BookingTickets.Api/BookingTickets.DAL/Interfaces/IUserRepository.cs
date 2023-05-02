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

        List<UserDto> GetAllCashiersByCinemaId(int cinemaId);

        void DeleteCashierById(int idCashier);

        public UserDto GetUserById(int idUser);

        public void UpdateUserStatus(UserDto user);
    }
}
