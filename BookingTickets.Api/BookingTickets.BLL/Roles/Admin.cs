using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models.All_SessionBLLModel;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private readonly SessionManager _sessionManager;

        public Admin()
        {
            _sessionManager = new SessionManager();
        }

        public void CreateSession(CreateSessionInputModel session)
        {
            _sessionManager.CreateSession(session);
        }

        public void DeleteSession(int sessionId)
        {
            _sessionManager.DeleteSession(sessionId);
        }
    }
}
