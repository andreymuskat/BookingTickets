using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private readonly SessionManager _sessionManager;
        private readonly UserManager _userManager;

        public Admin()
        {
            _sessionManager = new SessionManager();
            _userManager = new UserManager();
        }

        public void CreateSession(CreateSessionInputModel session)
        {
            _sessionManager.CreateSession(session);
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
    }
}
