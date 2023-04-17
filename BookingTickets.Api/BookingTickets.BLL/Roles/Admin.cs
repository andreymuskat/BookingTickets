using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly SessionManager _sessionManager;

        public Admin(SessionManager sessionManager) 
        {
            _sessionManager = sessionManager;
        }

        public void CreateSession(SessionBLL session)
        {
            _sessionManager.CreateSession(session);
        }
    }
}
