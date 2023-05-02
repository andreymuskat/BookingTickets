using BookingTickets.BLL.Models;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using Core;

namespace BookingTickets.BLL
{
    public class UserManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();
            _authRepository = new AuthRepository();
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

        public UserBLL GetUserByName(string name)
        {
            return _instanceMapperBll.MapUserDtoToUserBLL(_authRepository.GetUserByName(name));
        }

        public void ChangeUserStatus(UserStatus status, int userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user != null)
            {
                user.UserStatus = status;
            }
            else { throw new UserExceptions(777); }

            _userRepository.UpdateUserStatus(user);
        }

        public UserBLL GetUserById(int userId)
        {
            return _instanceMapperBll.MapUserDtoToUserBLL(_userRepository.GetUserById(userId));
        }
    }
}