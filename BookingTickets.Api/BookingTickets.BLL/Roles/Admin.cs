using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.All_SessionBLLModel;
using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

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
    }
}
