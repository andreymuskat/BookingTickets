using AutoMapper;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.InputModel.All_Session_InputModel;
using BookingTickets.BLL.Models.InputModel.All_User_InputModel;
using BookingTickets.Core.CustomException;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL.Models;
using Core.Status;
using Microsoft.AspNetCore.Http;

namespace BookingTickets.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;
        private readonly ISessionRepository _sessionRepository;

        public UserManager(IMapper map, IUserRepository userRepository, IAuthRepository authRepository, ISessionRepository sessionRepository)
        {
            _mapper = map;
            _userRepository = userRepository;
            _authRepository = authRepository;
            _sessionRepository = sessionRepository;
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

        public void DeleteCashierById(int idCashier)
        {
            var cashier = _userRepository.GetCashierById(idCashier);

            if (cashier != null)
            {
                _userRepository.DeleteCashierById(idCashier);
            }
            else
            {
                throw new SessionException(777);
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
                throw new UserExceptions(777);
            }

            _userRepository.UpdateUserStatus(user);
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
                throw new CinemaException(777);
            }           
        }

        public void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int CinemaId)
        {
            var allTrueSessions = _mapper.Map<List<CreateSessionInputModel>>(_sessionRepository.GetAllSessionByDate(dateCopy).Where(a => a.Hall.CinemaId == CinemaId).ToList());

            foreach (var session in allTrueSessions)
            {
                session.Date = dateWhereToCopy.AddHours(session.Date.Hour).AddMinutes(session.Date.Minute).AddSeconds(session.Date.Second);
                var res = _mapper.Map<SessionDto>(session);
                _sessionRepository.CreateSession(res);
            }
        }
    }
}