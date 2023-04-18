using BookingTickets.BLL.Models;
using BookingTickets.DAL;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class SessionManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ISessionRepository _sessionRepository;

        public SessionManager()
        {
            _sessionRepository = new SessionRepository();
        }

        public void CreateSession(SessionBLL session)
        {

        }
    }
}
