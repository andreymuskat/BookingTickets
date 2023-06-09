using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.ILogger;
using Core.Status;

namespace BookingTickets.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly INLogLogger _logger;


        public UserManager(IMapper map, IUserRepository userRepository, IAuthRepository authRepository,
            ISessionRepository sessionRepository, INLogLogger logger)
        {
            _mapper = map;
            _userRepository = userRepository;
            _authRepository = authRepository;
            _sessionRepository = sessionRepository;
            _logger = logger;
        }

        public List<UserBLL> GetAllUsers()
        {
            var allUsers = _userRepository.GetAllUsers();

            return _mapper.Map<List<UserBLL>>(allUsers);
        }

        public List<UserBLL> GetAllCashiers()
        {
            var allCashiers = _userRepository.GetAllCashiers();

            if (allCashiers != null)
            {
                return _mapper.Map<List<UserBLL>>(allCashiers);
            }
            else
            {
                _logger.Warn("Object not found in database.");

                throw new UserExceptions(777);
            }            
        }

        public void DeleteCashierById(int idCashier, int adminCinemaId)
        {
            var cashier = _userRepository.GetCashierById(idCashier);

            if (cashier.CinemaId != adminCinemaId)
            {
                throw new UserExceptions(205);
            }
            else
            {
                if (cashier != null)
                {
                    _userRepository.DeleteCashierById(idCashier);
                }
                else
                {
                    _logger.Warn("Object not found in database.");

                    throw new UserExceptions(777);
                }
            }
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
            else
            {
                _logger.Warn("Object not found in database.");

                throw new UserExceptions(777);
            }

            _userRepository.UpdateUserStatus(user);
        }

        public void ChangeUserCinemaId(int cinemaId, int userId)
        {
            var user = _userRepository.GetUserById(userId);

            if (user != null)
            {
                user.CinemaId = cinemaId;
            }
            else
            {
                _logger.Warn("Object not found in database.");

                throw new UserExceptions(777);
            }

            _userRepository.UpdateUserCinemaId(user);
        }

        public UserBLL GetUserById(int userId)
        {
            return _mapper.Map<UserBLL>(_userRepository.GetUserById(userId));
        }

        public UserBLL GetCashierById(int cashierId)
        {
            return _mapper.Map<UserBLL>(_userRepository.GetUserById(cashierId));
        }

        public UserBLL UpdateCashier(UpdateCashierInputModel cashier, int cashierId)
        {
            var userDto = _mapper.Map<UserDto>(cashier);

            var cash = _userRepository.GetCashierById(cashierId);

            if (cash != null)
            {
                userDto.Id = cashierId;
                return _mapper.Map<UserBLL>(_userRepository.UpdateCashier(userDto));
            }
            else
            {
                _logger.Warn("Object not found in database.");

                throw new CinemaException(777);
            }
        }
    }
}