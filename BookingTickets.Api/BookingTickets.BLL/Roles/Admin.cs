using BookingTickets.BLL;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly SessionManager _sessionManager;

        public Admin() 
        {
            _sessionManager = new SessionManager();
        }

        public void CreateSession(SessionBLL session)
        {
            _sessionManager.CreateSession(session);
        }

        public void CreateCashier(UserBLL user)
        {

        }
    }
}
