using BookingTickets.BLL.Models;
using BookingTickets.DAL.Interfaces;

namespace BookingTickets.BLL
{
    public class SessionManager
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly ISessionRepository _repository;

        public SessionManager(ISessionRepository repository)
        {
            _repository = repository;
        }

        public void CreateSession(SessionBLL session)
        {
            _repository.CreateSession(_instanceMapperBll.MapSessionBLLToSessionDto(session));
        }
    }
}
