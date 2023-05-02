using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.Status;

namespace BookingTickets.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;

        public UserManager(IMapper map, IUserRepository userRepository, IAuthRepository authRepository)
        {
            _mapper = map;
            _userRepository = userRepository;
            _authRepository = authRepository;
        }

        public List<UserBLL> GetAllUsers()
        {
            var allUsers = _userRepository.GetAllUsers();

            return _mapper.Map<List<UserBLL>>(allUsers);
        }

        public List<UserBLL> GetAllCashiers()
        {
            var allUsers = _userRepository.GetAllCashiers();

            return _mapper.Map<List<UserBLL>>(allUsers);
        }

        public UserBLL CreateNewCashier(CreateCashierInputModel user)
        {
            var userDto = _mapper.Map<UserDto>(user);
            var resUserBLL = _mapper.Map<UserBLL>(_userRepository.CreateNewCashier(userDto));

            return resUserBLL;
        }

        public void DeleteCashierById(int idCashier)
        {
            _userRepository.DeleteCashierById(idCashier);
        }

        public UserBLL GetUserByName(string name)
        {
            return _mapper.Map<UserBLL>(_authRepository.GetUserByName(name));
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
            return _mapper.Map<UserBLL>(_userRepository.GetUserById(userId));
        }
    }
}