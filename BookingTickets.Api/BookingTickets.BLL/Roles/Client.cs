using BookingTickets.BLL.InterfacesBll;
using BookingTickets.BLL.Models;

namespace BookingTickets.BLL.Roles
{
    public class Client : IClient
    {
        private MapperBLL _instanceMapperBll = MapperBLL.getInstance();
        private readonly FilmManager _filmManager;
        private readonly SessionManager _sessionManager;

        public Client()
        {
            _filmManager = new FilmManager();
            _sessionManager = new SessionManager();
        }

        public FilmBLL GetFilmById(int id)
        {
            return _filmManager.GetFilmById(id);
        }

        public List<SessionBLL> GetFilmsByCinema(int cinemaId)
        {
            return _sessionManager.GetAllSessionByCinemaId(cinemaId);
        }
    }
}
