using BookingTickets.BLL;
using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;
using BookingTickets.BLL.Models.All_SessionBLLModel;

namespace BookingTickets.BLL.Roles
{
    public class Admin : IAdmin
    {
        private readonly SessionManager _sessionManager;

        public Admin(SessionManager sessionManager) 
        {
            _sessionManager = sessionManager;
        }

        public void CreateSession(CreateSessionInputModel session)
        {
            
        }

        public void CreateCashier(UserBLL user)
        {

        }
    }
}
