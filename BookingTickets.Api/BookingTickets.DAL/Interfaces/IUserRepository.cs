using BookingTickets.DAL.Models;

namespace BookingTickets.DAL.Interfaces
{
    public interface IUserRepository
    {
        public List<UserDto> GetAllUsers();

        public UserDto GetUserById(int id);

        public void CreateCashier(UserDto cashier);
    }
}
