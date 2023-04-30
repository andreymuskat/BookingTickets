using BookingTickets.BLL.Models;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL;
using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;

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

        public void ChangeUserStatus(ChangeUserStatusInputModel newUser)
        {
            var user = _userRepository.GetUserById(newUser.userId);

            if (user != null)
            {
                user.UserStatus = (Core.UserStatus)(newUser.newUserStatus);
            }
            else { throw new UserExceptions(777); }

            _userRepository.UpdateUserStatus(user);
        }
    }
}