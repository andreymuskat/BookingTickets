using BookingTickets.BLL.Models;
using BookingTickets.DAL.Interfaces;
using BookingTickets.DAL;
using BookingTickets.BLL.Models.All_UserBLLModels;

namespace BookingTickets.BLL
{
    public class UserManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly IUserRepository _userRepository;
        private readonly IAuthRepository _authRepository;
        private readonly ISessionRepository _sessionRepository;

        public UserManager()
        {
            _userRepository = new UserRepository();
            _sessionRepository = new SessionRepository();
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

        public UserBLL UpdateCashier(UpdateCashierInputModel user)
        {
            var userDto = _instanceMapperBll.MapUpdateCashierInputModelToUserDto(user);
            var resUserBLL = _instanceMapperBll.MapUserDtoToUserBLL(_userRepository.UpdateCashier(userDto));

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

        public void CopySession(DateTime dateCopy, DateTime dateWhereToCopy, int CinemaId)
        {
            var allTrueSessions = _instanceMapperBll.MapListSessionsDtoToListCreateSessionInputModel(_sessionRepository.GetAllSessionByDate(dateCopy));
            
            foreach (var session in allTrueSessions)
            {
                session.Date = dateWhereToCopy.AddHours(session.Date.Hour).AddMinutes(session.Date.Minute).AddSeconds(session.Date.Second);
                var res = _instanceMapperBll.MapCreateSessionInputModelToSessionDto(session);
                _sessionRepository.CreateSession(res);
            }
        }
    }
}