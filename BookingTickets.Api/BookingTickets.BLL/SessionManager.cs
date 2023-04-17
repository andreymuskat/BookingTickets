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
            if(session.FilmDto != null && session.Cost != null && session.Date != null)
            {
                if (session.Cost < 0)
                {
                    throw new ArgumentException("Цена билета не может быть меньше 0 !");
                }
                else
                {
                    _sessionRepository.CreateSession(_instanceMapperBll.MapSessionBLLToSessionDto(session));
                }
            }
            else
            {
                throw new ArgumentException("Нужно заполнить все поля!");
            }
        }
    }
}
