using BookingTickets.BLL.Models;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL;
using BookingTickets.DAL.Models;
using BookingTickets.BLL.Models.All_UserBLLModels;

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

            return _instanceMapperBll.MapListUserDtoToListUserBLL(allUsers);
        }
        
        public List<UserBLL> GetAllCashiers()
        {
            var allUsers = _userRepository.GetAllCashiers();

            return _instanceMapperBll.MapListUserDtoToListUserBLL(allUsers);
        }

        public UserBLL CreateNewCashier(CreateCashierInputModel user)
        {
            var userDto = _instanceMapperBll.MapCreateCashierInputModelToUserDto(user);
            var resUserBLL = _instanceMapperBll.MapUserDtoToUserBLL(_userRepository.CreateNewCashier(userDto));

            return resUserBLL;
        }

        public void DeleteCashierById(int idCashier)
        {
            _userRepository.DeleteCashierById(idCashier);
        }
    }
}