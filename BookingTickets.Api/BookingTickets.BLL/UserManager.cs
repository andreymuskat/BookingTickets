using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL;

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
    }
}
