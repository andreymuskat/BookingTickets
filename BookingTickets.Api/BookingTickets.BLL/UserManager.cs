using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class UserManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IUserRepository _userRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();

        }

        public List<UserBLL> GetAllUsers()
        {
            var allUsers = _userRepository.GetAllUsers();

            return _instanceMapperBll.MapListUserDtoUserBLL(allUsers);
        }

    }
}