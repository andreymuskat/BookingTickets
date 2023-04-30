using BookingTickets.BLL.CustomException;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Models.All_UserBLLModels;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private readonly SessionManager _sessionManager;
        private readonly UserManager _userManager;
        private readonly CinemaManager _cinemaManager;

        public Admin()
        {
            _sessionManager = new SessionManager();
            _userManager = new UserManager();
            _cinemaManager = new CinemaManager();
        }

        public void CreateSession(CreateSessionInputModel session, int cinemaId)
        {
            var cinemaBll = _cinemaManager.GetCinemaByHallId(session.HallId);

            if (cinemaBll.Id == cinemaId)
            {
                _sessionManager.CreateSession(session);
            }
            else
            {
                throw new SessionException(205);
            }
        }

        public void DeleteSession(int sessionId)
        {
            _sessionManager.DeleteSession(sessionId);

        }

        public List<UserBLL> GetAllUsers()
        {
            var allUsers = _userManager.GetAllUsers();

            return allUsers;
        }

        public List<UserBLL> GetAllCashiers()
        {
            var allUsers = _userManager.GetAllCashiers();

            return allUsers;
        }

        public UserBLL CreateNewCashier(CreateCashierInputModel newUser)
        {
            var res = _userManager.CreateNewCashier(newUser);

            return res;
        }

        public void DeleteCashierById(int id)
        {
            _userManager.DeleteCashierById(id);
        }
    }
}
